/* ============================================================================
 *
 * Title:      ReverseReplicationSetup.sql
 *
 * Description:   Configures a SQL Server database
 *
 * Author:     Steve Ives
 *          Synergex Professional Services Group
 *
 * Date:    7th September 2012
 *
 * ============================================================================
 *
 * Replicator requirements:
 *
 * 1. All tables to be replicated must have a "uniqueidentifier" column named
 *    "RowGUID" which is automatically assigned on insert and never changes.
 * 2. An index should be created for the RowGUID column in each replicated
 *    table.
 * 3. If the table already contains rows then the RowGUID column must be
 *    populated for those rows.
 * 4. All matching ISAM files must have a field named RowGUID.
 * 5. All matching ISAM files must have a key named RowGUID
 * 6. IF the ISAM files contain existing data then the RowGUID fields must be
 *    populated with the same values as exist in the matching database table
 *    row. This could be quite a challenge!
 * 7. The ISAM files that are being updated by the replication from SQL process
 *    must NEVER be modified by Synergy code. Only the replication process is
 *    allowed to update those files. I would recommend using OpenVMS ACL's to
 *    ensure that only the replication process can open the files for update.
 *
 * Replicator process:
 *
 * 1. Connect to database
 * 2. Check that ToReplicate table exists and exit with error if not.
 * 3. Check that all tables to be replicated exist and exit with error if not.
 * 4. Open a log file.
 * 5. Open all ISAM files. If a file is not found then write an error to the
 *    log file and exit.
 * 6. Start processing loop
 *    a) Check for a system wide logical which indicates that the replicator
 *       process should terminate. If sound then write an "exiting" message
 *       to the log file and exit from the processing loop.
 *    b)  Sleep for some period of time that is determined by a system wide
 *       logical name. The value of the logical name should be checked each
 *       time around the loop so that the sleep interval can be changed on
 *       the fly without having to restart the process.
 *    c) Retrieve the first row from the ToReplicate table.
 *    d) If no row was found then loop back around, otherwise:
 *       i) If it's an INSERT then read the row from the database and STORE
 *          a new record to the ISAM file. If the record already exists it
 *          will be deleted, a new record created, and an error will be
 *          logged to the log file.
 *       ii) If it's a DELETE then read the row from the database, read and
 *          lock the record in the ISAM file, and then overwrite the record
 *          with the new data from the database. If the record is not found
 *          then a new record will be created, and an error will be logged
 *          in the log file.
 *       iii)If it's a DELETE then read and lock the ISAM file record via the
 *          RowGUID key, and delete the record. If the record is not found
 *          then an error will be logged in the log file.
 *       iv)   Delete the replication instruction row from the database.
 *       v) Loop back around, suppressing the sleep so that other existing
 *          instructions will be processed immediately.
 * 7. Disconnect from the database.
 * 8. Close all the ISAM files.
 * 8. Close the log file.
 *
 * ============================================================================
 */
