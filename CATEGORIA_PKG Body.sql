--------------------------------------------------------
--  DDL for Package Body CATEGORIA_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE BODY "IASSIST"."CATEGORIA_PKG" AS 


  PROCEDURE GET_CATEGORIA_BY_ID
  (
      P_ID IN operadores.idoperador%TYPE,
      P_OBJECTHASH IN operadores.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  )
   IS
  BEGIN
  
  UPDATE AFILIADOS SET AFILIADOS.objecthash = P_OBJECTHASH WHERE AFILIADOS.IDAFILIADO = P_ID;
  
  LIST_CATEGORIA (P_ID, NULL, INT_NULL,INT_NULL, INT_NULL, NULL, R_CURSOR);
  
  END GET_CATEGORIA_BY_ID;

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 
   PROCEDURE LIST_CATEGORIA
 (
    P_ID IN NUMBER,
    P_CODIGO IN CATAGORIAS.CODIGO%TYPE,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 )IS
 
  strsql varchar2(32000);
  isWhere boolean:= false; 
 BEGIN 

  strsql:= 'SELECT IDCATEGORIA,
                 NOMBRE,
                 DESCRIPCION,
                 ESTADO,
                 OBJECTHASH,
                 CODIGO
           FROM CATAGORIAS' ;
           
  IF (P_ID <> INT_NULL) THEN
    strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'IDCATEGORIA=' || P_ID;
  END IF;              
  
  IF (P_CODIGO IS NOT NULL) THEN
    strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'CODIGO=' || P_CODIGO;
  END IF;      
  
    -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  
  
  IF(P_IS_PAGED=1) THEN
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  END IF;  
  
  Open R_CURSOR for strsql;
  
 END LIST_CATEGORIA;
  

END CATEGORIA_PKG;

/
