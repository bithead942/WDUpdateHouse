<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <Alerts>
    	<xsl:for-each select="//parameters/hazards">
      		<A><xsl:value-of select="hazard-conditions/hazard/@headline"/></A>
    	</xsl:for-each>
    </Alerts>
  </xsl:template>
</xsl:stylesheet>
