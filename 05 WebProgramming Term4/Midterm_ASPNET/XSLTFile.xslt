<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" >
<xsl:output method="html" indent="yes"/>

<!--starting up the root:-->
<xsl:template match="/">
<div>
  
  <!--displaying messages to the user:-->
  <H1>Itneraries of <xsl:value-of select="count(/itineraries/itinerary/passenger)"/> passengers</H1>          

  <!-- table:-->
  <table border="2">
    <xsl:for-each select="/itineraries/itinerary">
      <tr>
        <th colspan="3">
          <xsl:value-of select="passenger" />
        </th>
      </tr>
      <tr>
        <th> </th>
        <th>Departure</th>
        <th>Arriving</th>
      </tr>
      <tr>
        <td>
          Outbound
        </td>
        <td>
          <xsl:value-of select="outbound/departure/city" />
        </td>
        <td>
          <xsl:value-of select="outbound/arriving/city" />
        </td>
      </tr>
      <tr>
        <td>
          Return
        </td>
        <td>
          <xsl:value-of select="return/departure/city" />
        </td>
        <td>
          <xsl:value-of select="return/arriving/city" />
        </td>
      </tr>
    </xsl:for-each>
  </table>
</div>
</xsl:template>
</xsl:stylesheet>
