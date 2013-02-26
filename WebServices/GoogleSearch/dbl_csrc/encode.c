/*

	A module which makes data compression/decompression and encoding/decoding routines available
	to Synergy DBL.

	The layout of the parameters is the same as XCALL COMPRESS:

	xcall encode(function, outbuf, inbuf, outlength)

	Parameters:

	function	-	The function to perform.
					0 = zlib deflate
					1 = zlib inflate
					2 = gzip compress
					3 = gzip uncompress
					4 = base64 encode
					5 = base64 decode
	outbuf			The data area to receive the transformed data
	inbuf			The data area containing the source data
	outlength		The number of bytes of transformed data written

*/
#include <stdio.h>
#include "zlib.h"
#include "xcall.h"
#include <string.h>
#include <stdlib.h>

#define	ZLIB_DEFLATE 0
#define	ZLIB_INFLATE 1
#define	GZIP_COMPRESS 2
#define	GZIP_UNCOMPRESS 3
#define	BASE64_ENCODE 4
#define	BASE64_DECODE 5

unsigned char gzipHeader[10] = {0x1f, 0x8b, 8, 0, 0, 0, 0, 0, 0, 3};

unsigned char zlibFlags[2] = {0x78, 0x9c};		// 2 byte prefix to zlib-compressed data

/* Table of CRCs of all 8-bit messages. */
uint32 crc_table[256];

/* Flag: has the table been computed? Initially false. */
int crc_table_computed = 0;

/* Make the table for a fast CRC. */
void make_crc_table(void)
{
	uint32 c;
	int n, k;
	
	for (n = 0; n < 256; n++)
	{
		c = (uint32) n;
		for (k = 0; k < 8; k++)
		{
		if (c & 1)
			c = 0xedb88320L ^ (c >> 1);
		else
			c = c >> 1;
		}
		crc_table[n] = c;
	}
	crc_table_computed = 1;
}

/* Update a running CRC with the bytes buf[0..len-1]--the CRC
  should be initialized to all 1's, and the transmitted value
  is the 1's complement of the final running CRC (see the
  crc() routine below)). */

uint32 update_crc(uint32 crc, unsigned char *buf, int len)
{
	uint32 c = crc;
	int n;
	
	if (!crc_table_computed)
		make_crc_table();
	for (n = 0; n < len; n++)
	{
		c = crc_table[(c ^ buf[n]) & 0xff] ^ (c >> 8);
	}
	return c;
}

/* Return the CRC of the bytes buf[0..len-1]. */
uint32 crc(unsigned char *buf, int len)
{
	return update_crc(0xffffffffL, buf, len) ^ 0xffffffffL;
}

/* ===========================================================================
 *
 *	xcall encode(operation, dest_buff, source_buff, output_length)
 *
 *	operation		0 = zlib deflate
 *					1 = zlib inflate
 *					2 = gzip compress
 *					3 = gzip uncompress
 *					4 = base64 encode
 *					5 = base64 decode
 */
void dx_encode(DESCRIP **argblk)
{
    int err;
	int operation = get_xarg_val(argblk, 1);
	if ((long)argblk[0] != 4)
		dblerror(6);

	if (operation == ZLIB_DEFLATE)
	{
		z_stream c_stream; /* compression stream */

/*		Set up compression stream with pointers to the data, and the
		lengths of the data buffers */
		c_stream.zalloc = (alloc_func)0;
		c_stream.zfree = (free_func)0;
		c_stream.opaque = (voidpf)0;
		c_stream.next_in  = argblk[3]->addr;
		c_stream.next_out = argblk[2]->addr;
		c_stream.avail_in = argblk[3]->len;
		c_stream.avail_out = argblk[2]->len;

		put_xarg_val(argblk, 4, -1);	// Put error code in
		err = deflateInit(&c_stream, Z_DEFAULT_COMPRESSION);
		if (err == Z_OK)
		{
			err = deflate(&c_stream, Z_FINISH);
			if (err == Z_STREAM_END)
			{
				err = deflateEnd(&c_stream);
				if (err == Z_OK)
				{
					put_xarg_val(argblk, 4, c_stream.total_out);
				}
			}
		}
	}
	else if (operation == ZLIB_INFLATE)			// 1 = zlib inflate
	{
		z_stream c_stream; /* decompression stream */

/*		Set up decompression stream with pointers to the data, and the
		lengths of the data buffers */
		c_stream.zalloc = (alloc_func)0;
		c_stream.zfree = (free_func)0;
		c_stream.opaque = (voidpf)0;
		c_stream.next_in  = argblk[3]->addr;
		c_stream.next_out = argblk[2]->addr;
		c_stream.avail_in = argblk[3]->len;
		c_stream.avail_out = argblk[2]->len;

		put_xarg_val(argblk, 4, -1); // Put error code in
		err = inflateInit(&c_stream);
		if (err == Z_OK)
		{
			err = inflate(&c_stream, Z_FINISH);
			if (err == Z_STREAM_END)
			{
				err = inflateEnd(&c_stream);
				if (err == Z_OK)
				{
					put_xarg_val(argblk, 4, c_stream.total_out);
				}
			}
		}
	}
	else if (operation == GZIP_COMPRESS) // 2 = gzip compress
	{
		z_stream c_stream; /* compression stream */

/*		Create gzip trailer: CRC-32 checksum + original length*/
		uint32 trailer[2] = { crc(argblk[3]->addr, argblk[3]->len), argblk[3]->len };

/*		Set up compression stream with pointers to the data, and the
		lengths of the data buffers */
		c_stream.zalloc = (alloc_func)0;
		c_stream.zfree = (free_func)0;
		c_stream.opaque = (voidpf)0;
		c_stream.next_in  = argblk[3]->addr;
		c_stream.next_out = argblk[2]->addr + 8;
		c_stream.avail_in = argblk[3]->len;
		c_stream.avail_out = argblk[2]->len - 12;

		put_xarg_val(argblk, 4, -1);	// Put error code in
		err = deflateInit(&c_stream, Z_DEFAULT_COMPRESSION);
		if (err == Z_OK)
		{
			err = deflate(&c_stream, Z_FINISH);
			if (err == Z_STREAM_END)
			{
				err = deflateEnd(&c_stream);
				if (err == Z_OK)
				{
					memcpy(argblk[2]->addr, gzipHeader, sizeof(gzipHeader));
					memcpy(argblk[2]->addr + 8 + c_stream.total_out - 4, trailer, 8);
					put_xarg_val(argblk, 4, c_stream.total_out + 12);
				}
			}
		}
	}
	else if (operation == GZIP_UNCOMPRESS)			// 3 = gzip decompress
	{
		uint16 savedLast2OfHeader;		// Save the last 16 bits of the gzip header
										// which we overwrite with a faked zlib flag word.
		z_stream c_stream;				// decompression stream

		uint16 *h = (uint16 *)(argblk[3]->addr + 8);
		savedLast2OfHeader = *h;

/*		Put the zlib flag word in */
		*h = *((uint16*)(&zlibFlags[0]));

/*		Set up decompression stream with pointers to the data, and the
		lengths of the data buffers */
		c_stream.zalloc = (alloc_func)0;
		c_stream.zfree = (free_func)0;
		c_stream.opaque = (voidpf)0;
		c_stream.next_in  = argblk[3]->addr + 8;
		c_stream.next_out = argblk[2]->addr;
		c_stream.avail_in = argblk[3]->len - 16;
		c_stream.avail_out = argblk[2]->len;

		put_xarg_val(argblk, 4, -1); // Put error code in
		err = inflateInit(&c_stream);
		if (err == Z_OK)
		{
			err = inflate(&c_stream, Z_FINISH);
			if ((err == Z_STREAM_END) || (err == Z_BUF_ERROR)) // Ignore Z_BUF_ERROR!
			{
				err = inflateEnd(&c_stream);
				if (err == Z_OK)
				{
					put_xarg_val(argblk, 4, c_stream.total_out);
				}
			}
		}

/*		Restore the last 2 bytes of the gzip header which we overwrote
		with the zlib flag word */
		*h = savedLast2OfHeader;
	}
	else if (operation == BASE64_ENCODE)			// 4 = base64 encode
	{
		int l;
		if ((((argblk[3]->len + 2) / 3 * 4) + 1) > argblk[2]->len)
			dblerror(31); // $ERR_ARGSIZ if it won't fit
		put_xarg_val(argblk, 4, l = base64encode_binary(argblk[2]->addr, argblk[3]->addr, argblk[3]->len));
	}
	else if (operation == BASE64_DECODE)			// 5 = base64 decode
	{
		if ((((argblk[3]->len + 3) / 4) * 3) > argblk[2]->len)
			dblerror(31); // $ERR_ARGSIZ if it won't fit
		put_xarg_val(argblk, 4, base64decode_binary(argblk[2]->addr, argblk[3]->addr, argblk[3]->len));
	}
}
