--------------------------------------------------------
--  DDL for Package CATEGORIA_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE "IASSIST"."CATEGORIA_PKG" AS 

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 
  
  TYPE tyRefCursor is ref cursor;
  INT_NULL CONSTANT NUMBER:= -1;
  
  PROCEDURE GET_CATEGORIA_BY_ID
  (
      P_ID IN operadores.idoperador%TYPE,
      P_OBJECTHASH IN operadores.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  );
  
  PROCEDURE LIST_CATEGORIA
 (
    P_ID IN NUMBER,
    P_CODIGO IN CATAGORIAS.CODIGO%TYPE,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 );

END CATEGORIA_PKG;

/
