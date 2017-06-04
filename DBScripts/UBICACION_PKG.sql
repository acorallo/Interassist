--------------------------------------------------------
-- Archivo creado  - domingo-junio-04-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Package UBICACION_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE "IASSIST"."UBICACION_PKG" AS 
/*  EGV 03Jun2017 Creación de Paquete */

  TYPE tyRefCursor is ref cursor;
  INT_NULL CONSTANT NUMBER:= -1;

    PROCEDURE LIST_UBICACIONES 
    (
      P_ID IN number,
      P_IS_PAGED IN number,
      P_PAGE_START IN number,
      P_PAGE_SIZE IN number,
      P_ORDER_BY IN varchar2,
      P_SEARCH IN varchar2,
      R_CURSOR OUT tyRefCursor
    );   

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 

END UBICACION_PKG;

/
