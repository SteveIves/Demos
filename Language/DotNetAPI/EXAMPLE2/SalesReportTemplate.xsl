<html xsl:version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" lang="en">
  <head>
    <title>Sales Results By Division</title>
  </head>
  <body>
    <img src="spc2008.jpg" align="right"/>
    <h1 align="center">Synergy/DE .NET Assembly API</h1> <br/>
     <h2 align="center">XSL Transformation Example</h2> <br/> <br/> <br/> <hr/>
    <h1 align="center">Sales Results By Division (Decreasing Revenue)</h1>
    <table border="1" align="center">
    <tr>
      <th>Division</th>
      <th align="right">Revenue</th>
      <th align="right">Growth</th>
      <th align="right">Bonus</th>
    </tr>
    <xsl:for-each select="sales/division">
    <!-- order the result by revenue -->
    <xsl:sort select="revenue" data-type="number" order="descending"/>
    <tr>
      <td>
        <em><xsl:value-of select="@id"/></em> 
      </td>
      <td align="right">
        <xsl:value-of select="revenue"/>
      </td>
      <td align="right">
        <!-- highlight negative growth in red -->
        <xsl:if test="growth &lt; 0">
          <xsl:attribute name="style">
            <xsl:text>color:red</xsl:text>
          </xsl:attribute>
        </xsl:if>
        <xsl:value-of select="growth"/>
      </td>
      <td align="right">
        <xsl:value-of select="bonus"/>
      </td>
    </tr>
    </xsl:for-each>
    </table>
  </body>
</html>