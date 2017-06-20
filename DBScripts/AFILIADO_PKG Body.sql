--------------------------------------------------------
--  DDL for Package Body AFILIADO_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE BODY "IASSIST"."AFILIADO_PKG" AS 
 
 
  FUNCTION SPLIT_NOMBRE_APELLIDO(pNombre varchar2, pAellido varchar2) RETURN varchar2
  IS
    resultado varchar2(32000);
    v_array_nombre apex_application_global.vc_arr2;
    v_string varchar2(32000);
  BEGIN
    resultado:='';
  
    v_array_nombre := apex_util.string_to_table(pNombre, ' ');
    for i in 1..v_array_nombre.count
    loop
      resultado:= resultado || (v_array_nombre(i) || ' ' || pAellido || ' ');
    end loop;
    
    resultado := resultado || pNombre || ' ' || pAellido;
    
    RETURN resultado;
  END SPLIT_NOMBRE_APELLIDO;
 
  PROCEDURE GET_AFILIADO_BY_ID
  (
      P_ID IN operadores.idoperador%TYPE,
      P_OBJECTHASH IN operadores.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  )
   IS
  BEGIN
  
  UPDATE AFILIADOS SET AFILIADOS.objecthash = P_OBJECTHASH WHERE AFILIADOS.IDAFILIADO = P_ID;
  
  -- EGV 10Jun2017 Inicio
  --LIST_AFILIADO (P_ID, NULL, NULL, NULL,NULL,NULL,INT_NULL,NULL, INT_NULL,INT_NULL, INT_NULL, NULL, R_CURSOR);
  LIST_AFILIADO (P_ID, NULL, NULL, NULL,NULL,NULL,INT_NULL,0,NULL, INT_NULL,INT_NULL, INT_NULL, NULL, R_CURSOR);
  -- EGV 10Jun2017 Fin
  
  END GET_AFILIADO_BY_ID;
  
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
 )
 IS
    strsql varchar2(32000);
    isWhere boolean:= true; 
 
 BEGIN
 
    strsql:='SELECT A.IDAFILIADO,
                     A.APELLIDO,
                     A.NOMBRE,
                     A.POLIZA,
                     A.DIRECCION,
                     A.CODPOSTAL,
                     A.FECHADESDE,
                     A.FECHAHASTA,
                     A.IDDOCUMENTO,
                     A.MARCA,
                     A.PATENTE,
                     A.COLOR,
                     A.ANO,
                     A.OBJECTHASH,
                     A.IDEMPRESA,
                     A.CATEGORIA,
                     A.HOGAR,
                     A.MODELO,
                     A.ESTADO,
                     B.NOMBRE NOMBRE_EMPRESA,
                     C.NOMBRE CATAGORIA_NOMBRE
                FROM AFILIADOS A,
                     EMPRESAS B,
                     CATAGORIAS C
              WHERE A.IDEMPRESA = B.IDEMPRESA and
                    a.categoria = c.codigo and
                    A.FECHA_UPD IS NULL';
                
  IF (P_ID <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDAFILIADO=' || P_ID;
  END IF;
  
  
  IF (P_APELLIDO IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.APELLIDO) LIKE UPPER(''%' || P_APELLIDO || '%'')';
  END IF;  
  
  IF (P_NOMBRE IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.NOMBRE) LIKE UPPER(''%' || P_NOMBRE || '%'')';
  END IF;
  
  IF (P_POLIZA IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.POLIZA) LIKE UPPER(''%' || P_POLIZA || '%'')';
  END IF;

  IF (P_IDDOCUMENTO IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.IDDOCUMENTO) LIKE UPPER(''%' || P_IDDOCUMENTO || '%'')';
  END IF;  
  
  IF (P_PATENTE IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.PATENTE) LIKE UPPER(''%' || P_PATENTE || '%'')';
  END IF;  
  
  IF (P_ID_EMPRESA <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'IDEMPRESA=' || P_ID_EMPRESA;
  END IF;  
  
   IF(P_SEARCH IS NOT NULL) THEN 
   NULL;
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(AFILIADO_PKG.SPLIT_NOMBRE_APELLIDO(A.NOMBRE, A.APELLIDO)||A.IDAFILIADO||A.POLIZA||A.IDDOCUMENTO||A.PATENTE||B.NOMBRE||C.NOMBRE) LIKE UPPER(''%' || P_SEARCH || '%'')';
  END IF;
 
  -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  
  
  IF(P_IS_PAGED=1) THEN
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  END IF;  
  
  Open R_CURSOR for strsql;
 
 END LIST_AFILIADO_HUEARFANO;
 
  PROCEDURE LIST_AFILIADO_BY_PATENTE
 (
    P_PATENTE IN varchar2,
    P_IS_PAGED IN number,
    P_PAGE_START IN number,
    P_PAGE_SIZE IN number,
    P_ORDER_BY IN varchar2,
    R_CURSOR OUT tyRefCursor
 )
 IS
    strsql varchar2(32000);
    isWhere boolean:= true; 
 
 BEGIN
 
    strsql:='SELECT A.IDAFILIADO,
                     A.APELLIDO,
                     A.NOMBRE,
                     A.POLIZA,
                     A.DIRECCION,
                     A.CODPOSTAL,
                     A.FECHADESDE,
                     A.FECHAHASTA,
                     A.IDDOCUMENTO,
                     A.MARCA,
                     A.PATENTE,
                     A.COLOR,
                     A.ANO,
                     A.OBJECTHASH,
                     A.IDEMPRESA,
                     A.CATEGORIA,
                     A.HOGAR,
                     A.MODELO,
                     A.ESTADO,
                     B.NOMBRE NOMBRE_EMPRESA,
                     C.NOMBRE CATAGORIA_NOMBRE
                FROM AFILIADOS A,
                     EMPRESAS B,
                     CATAGORIAS C
              WHERE A.IDEMPRESA = B.IDEMPRESA and
                    a.categoria = c.codigo';
                


  IF (P_PATENTE IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.PATENTE) LIKE UPPER(''' || P_PATENTE || '%'')';
  END IF;  
   
  -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  
  
  IF(P_IS_PAGED=1) THEN
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  END IF;  
  
  DBMS_OUTPUT.PUT_LINE (strsql);
  
  Open R_CURSOR for strsql;
 
 END LIST_AFILIADO_BY_PATENTE;
 
 
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
 )
 IS
    strsql varchar2(32000);
    isWhere boolean:= true; 
 
 BEGIN
 
    strsql:='SELECT A.IDAFILIADO,
                     A.APELLIDO,
                     A.NOMBRE,
                     A.POLIZA,
                     A.DIRECCION,
                     A.CODPOSTAL,
                     A.FECHADESDE,
                     A.FECHAHASTA,
                     A.IDDOCUMENTO,
                     A.MARCA,
                     A.PATENTE,
                     A.COLOR,
                     A.ANO,
                     A.OBJECTHASH,
                     A.IDEMPRESA,
                     A.CATEGORIA,
                     A.HOGAR,
                     A.MODELO,
                     A.ESTADO,
                     B.NOMBRE NOMBRE_EMPRESA,
                     C.NOMBRE CATAGORIA_NOMBRE
                FROM AFILIADOS A,
                     EMPRESAS B,
                     CATAGORIAS C
              WHERE A.IDEMPRESA = B.IDEMPRESA and
                    a.categoria = c.codigo';
                
  IF (P_ID <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDAFILIADO=' || P_ID;
  END IF;
  
  
  IF (P_APELLIDO IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.APELLIDO) LIKE UPPER(''%' || P_APELLIDO || '%'')';
  END IF;  
  
  IF (P_NOMBRE IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.NOMBRE) LIKE UPPER(''%' || P_NOMBRE || '%'')';
  END IF;
  
  IF (P_POLIZA IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.POLIZA) LIKE UPPER(''%' || P_POLIZA || '%'')';
  END IF;

  IF (P_IDDOCUMENTO IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.IDDOCUMENTO) LIKE UPPER(''%' || P_IDDOCUMENTO || '%'')';
  END IF;  
  
  IF (P_PATENTE IS NOT NULL) THEN
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(A.PATENTE) LIKE UPPER(''%' || P_PATENTE || '%'')';
  END IF;  
  
  IF (P_ID_EMPRESA <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'IDEMPRESA=' || P_ID_EMPRESA;
  END IF;  
  
  -- EGV 10Jun2017 Inicio
  IF (P_VIGENTE = 1) THEN
    strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'trunc(sysdate) between A.FECHADESDE and nvl(A.FECHAHASTA,to_date(''31/12/2099'',''dd/mm/yyyy''))';
  END IF;
  -- EGV 10Jun2017 Fin
  
   IF(P_SEARCH IS NOT NULL) THEN 
   NULL;
    strsql:= strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(AFILIADO_PKG.SPLIT_NOMBRE_APELLIDO(A.NOMBRE, A.APELLIDO)||A.IDAFILIADO||A.POLIZA||A.IDDOCUMENTO||A.PATENTE||B.NOMBRE||C.NOMBRE) LIKE UPPER(''%' || P_SEARCH || '%'')';
  END IF;
 
  -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  
  
  IF(P_IS_PAGED=1) THEN
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  END IF;  
  
  Open R_CURSOR for strsql;
 
 END LIST_AFILIADO;
 
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
 )
 IS
  ID_INSERT NUMBER;
 BEGIN
    
    ID_INSERT:= SEQ_AFILIADOS.NEXTVAL;
    
    INSERT
    INTO AFILIADOS
      (
        IDAFILIADO,
        APELLIDO,
        NOMBRE,
        POLIZA,
        DIRECCION,
        CODPOSTAL,
        FECHADESDE,
        FECHAHASTA,
        IDDOCUMENTO,
        MARCA,
        PATENTE,
        COLOR,
        ANO,
        OBJECTHASH,
        IDEMPRESA,
        CATEGORIA,
        HOGAR,
        MODELO,
        ESTADO,
        TIPO_ALTA,
        FECHA_ALTA
      )
      VALUES
      (
        ID_INSERT,
        P_APELLIDO,
        P_NOMBRE,
        P_POLIZA,
        P_DIRECCION,
        P_CODPOSTAL,
        P_FECHADESDE,
        P_FECHAHASTA,
        P_IDDOCUMENTO,
        P_MARCA,
        P_PATENTE,
        P_COLOR,
        P_ANO,
        P_OBJECTHASH,
        P_ID_EMPRESA,
        P_CATEGORIA,
        P_HOGAR,
        P_MODELO,
        P_ESTADO,
        'M',
        SYSDATE
      );
      
    P_ID:= ID_INSERT;
  
 END CREATE_AFILIADO;
  
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
 ) IS
 BEGIN
  
    UPDATE AFILIADOS
    SET APELLIDO = P_APELLIDO
        ,NOMBRE = P_NOMBRE
        ,POLIZA = P_POLIZA
        ,DIRECCION = P_DIRECCION
        ,CODPOSTAL = P_CODPOSTAL
        ,FECHADESDE = P_FECHADESDE
        ,FECHAHASTA = P_FECHAHASTA
        ,IDDOCUMENTO = P_IDDOCUMENTO
        ,MARCA = P_MARCA
        ,PATENTE = P_PATENTE
        ,COLOR = P_COLOR
        ,ANO = P_ANO
        ,IDEMPRESA = P_ID_EMPRESA
        ,CATEGORIA = P_CATEGORIA
        ,HOGAR = P_HOGAR
        ,MODELO = P_MODELO
        ,ESTADO = P_ESTADO
    WHERE AFILIADOS.IDAFILIADO = P_ID and AFILIADOS.OBJECTHASH = P_OBJECTHASH;
  
   P_AFFECTED_ROWS:= sql%rowcount;  
  
 END MODIFY_AFILIADO;
 
 

END AFILIADO_PKG;

/
