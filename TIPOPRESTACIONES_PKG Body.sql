--------------------------------------------------------
--  DDL for Package Body TIPOPRESTACIONES_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE BODY "IASSIST"."TIPOPRESTACIONES_PKG" AS 


  PROCEDURE GET_TIPOPRESTACION_BY_ID
  (
      P_ID IN tipoprestaciones.idtipoprestacion%TYPE,
      P_OBJECTHASH IN tipoprestaciones.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  )
   IS
  BEGIN

  LIST_TIPOPRESTACION (P_ID, INT_NULL,INT_NULL, INT_NULL, NULL, R_CURSOR);

  END GET_TIPOPRESTACION_BY_ID;

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 
   PROCEDURE LIST_TIPOPRESTACION
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

  strsql:= 'SELECT IDTIPOPRESTACION,
                 CODIGO,
                 DESCRIPCION,
                 OBJECTHASH
           FROM TIPOPRESTACIONES' ;

    -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  

  IF(P_IS_PAGED=1) THEN
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  END IF;  

  Open R_CURSOR for strsql;

 END LIST_TIPOPRESTACION;


END TIPOPRESTACIONES_PKG;

/
