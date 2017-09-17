--------------------------------------------------------
--  DDL for Package TIPOPRESTACIONES_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE "IASSIST"."TIPOPRESTACIONES_PKG" AS 

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 

  TYPE tyRefCursor is ref cursor;
  INT_NULL CONSTANT NUMBER:= -1;

  PROCEDURE GET_TIPOPRESTACION_BY_ID
  (
      P_ID IN tipoprestaciones.idtipoprestacion%TYPE,
      P_OBJECTHASH IN tipoprestaciones.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  );

  PROCEDURE LIST_TIPOPRESTACION
 (
    P_ID IN NUMBER,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 );

END TIPOPRESTACIONES_PKG;

/
