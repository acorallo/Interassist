--------------------------------------------------------
-- Archivo creado  - domingo-junio-04-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Package ESTADO_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE "IASSIST"."ESTADO_PKG" AS 

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 
  TYPE tyRefCursor is ref cursor;
  INT_NULL CONSTANT NUMBER:= -1;

   PROCEDURE LIST_ESTADOS
   (
      P_ID IN estados.idestado%type,
      P_GRUPO estados.grupo%type,
      P_IS_PAGED IN number,
      P_PAGE_START IN number,
      P_PAGE_SIZE IN number,
      P_ORDER_BY IN varchar2,
      R_CURSOR OUT tyRefCursor
   );

END ESTADO_PKG;

/
