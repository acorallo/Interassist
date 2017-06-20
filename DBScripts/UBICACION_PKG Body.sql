--------------------------------------------------------
--  DDL for Package Body UBICACION_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE BODY "IASSIST"."UBICACION_PKG" AS
/*  EGV 03Jun2017 Creación de Paquete */

  PROCEDURE LIST_UBICACIONES 
    (
      P_ID IN number,
      P_IS_PAGED IN number,
      P_PAGE_START IN number,
      P_PAGE_SIZE IN number,
      P_ORDER_BY IN varchar2,
      P_SEARCH IN varchar2,
      R_CURSOR OUT tyRefCursor
    ) IS
    
    strsql varchar2(32000);
    isWhere boolean:= false; 

  BEGIN
    
    strsql:='SELECT A.*, CASE WHEN UPPER(A.NOMBRE) LIKE UPPER(''' || P_SEARCH || '%'') THEN 0 ELSE 1 END + CASE WHEN PROVINCIA = ''CIUDAD AUTÓNOMA DE BUENOS AIRES'' THEN 0 ELSE CASE WHEN PROVINCIA = ''BUENOS AIRES'' THEN 1 ELSE 2 END END AS ORDEN 
                FROM UBICACIONES_VW A';

  IF (P_ID <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDLOCALIDAD=' || P_ID;
  END IF;

                
   IF(P_SEARCH IS NOT NULL) THEN 
   NULL;
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.NOMBRE) LIKE UPPER(''%' || P_SEARCH || '%'')';
  END IF;
 
  -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  
  
  IF(P_IS_PAGED=1) THEN
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  END IF;  
  
  Open R_CURSOR for strsql;
    
    
  END LIST_UBICACIONES;

END UBICACION_PKG;

/
