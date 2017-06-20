--------------------------------------------------------
--  DDL for Package AFILIADO_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE "IASSIST"."AFILIADO_PKG" AS   
  
  TYPE tyRefCursor is ref cursor;
  INT_NULL CONSTANT NUMBER:= -1;

  FUNCTION SPLIT_NOMBRE_APELLIDO(pNombre varchar2, pAellido varchar2) RETURN varchar2;
  
  PROCEDURE GET_AFILIADO_BY_ID
  (
      P_ID IN operadores.idoperador%TYPE,
      P_OBJECTHASH IN operadores.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  );
  
  
  PROCEDURE LIST_AFILIADO_BY_PATENTE
 (
    P_PATENTE IN varchar2,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 );
  
  PROCEDURE LIST_AFILIADO
 (
    P_ID IN afiliados.idafiliado%type,
    P_APELLIDO IN afiliados.APELLIDO%type,
    P_NOMBRE IN afiliados.NOMBRE%type,
    P_POLIZA IN afiliados.POLIZA%type,
    P_IDDOCUMENTO IN afiliados.IDDOCUMENTO%type,
    P_PATENTE IN afiliados.PATENTE%type,
    P_ID_EMPRESA IN afiliados.idempresa%type,
    P_VIGENTE IN integer,       -- EGV 10Jun2017
    P_SEARCH IN varchar2,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 );
 
 PROCEDURE LIST_AFILIADO_HUEARFANO
 (
    P_ID IN afiliados.idafiliado%type,
    P_APELLIDO IN afiliados.APELLIDO%type,
    P_NOMBRE IN afiliados.NOMBRE%type,
    P_POLIZA IN afiliados.POLIZA%type,
    P_IDDOCUMENTO IN afiliados.IDDOCUMENTO%type,
    P_PATENTE IN afiliados.PATENTE%type,
    P_ID_EMPRESA IN afiliados.idempresa%type,
    P_SEARCH IN varchar2,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 );

 PROCEDURE CREATE_AFILIADO
 (
    P_ID OUT afiliados.idafiliado%type,
    P_APELLIDO IN afiliados.APELLIDO%type,
    P_NOMBRE IN afiliados.NOMBRE%type,
    P_POLIZA IN afiliados.POLIZA%type,
    P_DIRECCION IN afiliados.DIRECCION%type,
    P_CODPOSTAL IN afiliados.CODPOSTAL%type,
    P_FECHADESDE IN afiliados.FECHADESDE%type,
    P_FECHAHASTA IN afiliados.FECHAHASTA%type,
    P_IDDOCUMENTO IN afiliados.IDDOCUMENTO%type,
    P_MARCA IN afiliados.MARCA%type,
    P_PATENTE IN afiliados.PATENTE%type,
    P_COLOR IN afiliados.COLOR%type,
    P_ANO IN afiliados.ANO%type,
    P_CATEGORIA IN afiliados.categoria%type,
    P_OBJECTHASH IN afiliados.objecthash%type,
    P_ID_EMPRESA IN afiliados.idempresa%type,
    P_HOGAR IN afiliados.hogar%TYPE,
    P_MODELO afiliados.modelo%TYPE,
    P_ESTADO afiliados.estado%TYPE
 );
 
  PROCEDURE MODIFY_AFILIADO 
 (
    P_ID IN afiliados.idafiliado%type,
    P_APELLIDO IN afiliados.APELLIDO%type,
    P_NOMBRE IN afiliados.NOMBRE%type,
    P_POLIZA IN afiliados.POLIZA%type,
    P_DIRECCION IN afiliados.DIRECCION%type,
    P_CODPOSTAL IN afiliados.CODPOSTAL%type,
    P_FECHADESDE IN afiliados.FECHADESDE%type,
    P_FECHAHASTA IN afiliados.FECHAHASTA%type,
    P_IDDOCUMENTO IN afiliados.IDDOCUMENTO%type,
    P_MARCA IN afiliados.MARCA%type,
    P_PATENTE IN afiliados.PATENTE%type,
    P_COLOR IN afiliados.COLOR%type,
    P_ANO IN afiliados.ANO%type,
    P_CATEGORIA IN afiliados.categoria%type,
    P_OBJECTHASH IN afiliados.objecthash%type,
    P_ID_EMPRESA IN afiliados.idempresa%type,
    P_HOGAR IN afiliados.hogar%type,
    P_MODELO afiliados.modelo%TYPE,
    P_ESTADO afiliados.estado%TYPE,
    P_AFFECTED_ROWS OUT NUMBER   
 );
  
END AFILIADO_PKG;

/
