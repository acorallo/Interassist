--------------------------------------------------------
-- Archivo creado  - domingo-junio-04-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Package Body ESTADO_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE BODY "IASSIST"."ESTADO_PKG" AS 

  /* TODO enter package declarations (types, exceptions, methods etc) here */ 

   PROCEDURE LIST_ESTADOS
   (
      P_ID IN estados.idestado%type,
      P_GRUPO estados.grupo%type,
      P_IS_PAGED IN number,
      P_PAGE_START IN number,
      P_PAGE_SIZE IN number,
      P_ORDER_BY IN varchar2,
      R_CURSOR OUT tyRefCursor
   )
   IS
        strsql varchar2(32000);
        isWhere boolean:= false;
   BEGIN

        strsql := 'SELECT * FROM ESTADOS';

        IF (P_ID <> INT_NULL) THEN
            strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'idestado=' || P_ID;
        END IF;       

        IF (P_GRUPO IS NOT NULL) THEN
            strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'grupo=''' || P_GRUPO || '''';
        END IF;

        IF (P_ORDER_BY IS NOT NULL) THEN  
            strsql:= strsql || P_ORDER_BY;
        END IF;

        IF(P_IS_PAGED=1) THEN
            strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
        END IF;

        Open R_CURSOR for strsql;

   END;

END ESTADO_PKG;

/
