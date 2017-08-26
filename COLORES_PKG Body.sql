--------------------------------------------------------
--  DDL for Package Body COLORES_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE BODY "IASSIST"."COLORES_PKG" AS 


  PROCEDURE GET_COLOR_BY_ID
  (
      P_ID IN colores.idcolor%TYPE,
      P_OBJECTHASH IN colores.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  )
   IS
  BEGIN

  LIST_COLOR (P_ID, INT_NULL,INT_NULL, INT_NULL, NULL, R_CURSOR);

  END GET_COLOR_BY_ID;

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 
   PROCEDURE LIST_COLOR
 (
    P_ID IN NUMBER,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 )IS

  strsql varchar2(32000);
  isWhere boolean:= true; 
 BEGIN 

  strsql:= 'SELECT IDCOLOR,
                 NOMBRE,
                 OBJECTHASH
           FROM COLORES' ;

    -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  

  IF(P_IS_PAGED=1) THEN
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  END IF;  

  Open R_CURSOR for strsql;

 END LIST_COLOR;


END COLORES_PKG;

/
