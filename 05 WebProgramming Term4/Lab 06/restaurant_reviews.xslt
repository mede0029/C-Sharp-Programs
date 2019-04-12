<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" >
<xsl:output method="xml" indent="yes"/>

  <!--creating parameter to receive user input:-->
  <xsl:param name ="ratingInput"/>  
  
  <!--starting up the root:-->
  <xsl:template match="/">
    <html>
      <body>
        <!--displaying messages for the user:-->
        <xsl:choose>
          <!--if counting restaurants with rating on xml greater than rating from user input is equal to 0:-->
          <xsl:when test="count(/restaurants/restaurant[rating > $ratingInput]) = 0">
            No restaurants have a rating above <xsl:value-of select="$ratingInput" />
          </xsl:when>
          <!--else:-->
          <xsl:otherwise>
            Displaying <xsl:value-of select="count(/restaurants/restaurant[rating > $ratingInput])"/> available restaurant(s) above the selected rating:
          </xsl:otherwise>
        </xsl:choose>
        <xsl:apply-templates select="/restaurants/restaurant" >
          <!--ordering restaurants by deschending rating order-->
          <xsl:sort select="rating" order="descending"/>
        </xsl:apply-templates>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="restaurant">
        
    <!--if rating from xml is greater than grading from user input:-->
    <xsl:if test="rating > $ratingInput" >          
      
      <!--restaurant name-->
      <H2> <xsl:value-of select="name" /> </H2>

      <!--restaurant address and phone number:-->
      <li>
        Address: <xsl:value-of select="address/street" />, <xsl:value-of select="address/city" />, <xsl:value-of select="address/province" />, <xsl:value-of select="address/postalCode" />
      </li>
      <li>
        Phone: (<xsl:value-of select="phone/areaCode" />) <xsl:value-of select="phone/number" />
      </li>

      <!--summary:-->
      <br/><br/>
      <H3>Summary</H3>
      <ul><xsl:value-of select="summary" /></ul>

      <!--rating:-->
      <H3>Rating: <xsl:value-of select="rating" /></H3>

      <!--menu table:-->
      <!--header-->
      <br/><br/><H3>Menu</H3>
      <table border ="1">
        <tr>
          <th>Description</th>
          <th>Quantity</th>
          <th>Price</th>
        </tr>        

        <!--appetizers-->
        <tr>
          <th colspan="3">Appetizers</th>
        </tr>
        <xsl:for-each select="menu/item[@type='appetizers']">
          <xsl:sort select="price" order="ascending"/>
          <tr>
            <td> 
              <xsl:value-of select="name" /> 
            </td>
            <td>        
              <xsl:choose>
                    <xsl:when test="not(bulk_price)">
                      1
                    </xsl:when>
                    <xsl:otherwise>
                      <xsl:for-each select="bulk_price">
                        <xsl:value-of select="@min_qty" />
                      </xsl:for-each>
                    </xsl:otherwise>
              </xsl:choose>
            </td>
            <td>
              <xsl:choose>
                <xsl:when test="not(bulk_price)">
                  <xsl:value-of select="price" />
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="bulk_price" />
                </xsl:otherwise>
              </xsl:choose>
            </td>
          </tr>
        </xsl:for-each>

        <!--entrees-->
        <tr>
          <th colspan="3">Entrees</th>
        </tr>        
        <xsl:for-each select="menu/item[@type='entree']">
          <xsl:sort select="price" order="ascending"/>
          <tr>
            <td> 
              <xsl:value-of select="name" /> 
            </td>            
            <td>
              <xsl:choose>
                <xsl:when test="not(bulk_price)">
                  1
                </xsl:when>
                <xsl:otherwise>
                  <xsl:for-each select="bulk_price">
                    <xsl:value-of select="@min_qty" />
                  </xsl:for-each>
                </xsl:otherwise>
              </xsl:choose>  
            </td>            
            <td>
              <xsl:choose>
                <xsl:when test="not(bulk_price)">
                  <xsl:value-of select="price" />
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="bulk_price" />
                </xsl:otherwise>
              </xsl:choose>
            </td>            
          </tr>
        </xsl:for-each>  
      </table>       
    </xsl:if>
  </xsl:template>  
</xsl:stylesheet>
