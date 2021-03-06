--------------------------------------------------------
--  DDL for Package Body TICKET_PKG
--------------------------------------------------------

  CREATE OR REPLACE PACKAGE BODY "IASSIST"."TICKET_PKG" AS 

  PROCEDURE GET_TICKET_BY_ID
  (
      P_ID IN prestadores.idprestador%TYPE,
      P_OBJECTHASH IN prestadores.objecthash%TYPE,
      R_CURSOR OUT tyRefCursor
  )
  IS
  BEGIN 
    
    UPDATE TICKETS SET TICKETS.objecthash = P_OBJECTHASH WHERE TICKETS.IDTICKET = P_ID;
    
    LIST_TICKET (P_ID, int_null, int_null, int_null, int_null, NULL,0, int_null, int_null, NULL, R_CURSOR);
    
  END GET_TICKET_BY_ID;




  PROCEDURE LIST_TICKET
  (
      P_ID IN tickets.idticket%TYPE,
      P_IDOPERADOR IN tickets.idoperador%TYPE,
      P_IDAFILIADO IN tickets.idafiliado%TYPE,
      P_CIUDAD_ORIGEN IN tickets.idciudad_origen%TYPE,
      P_CIUDAD_DESTINO IN tickets.idciudad_destino%TYPE,
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

        strsql:='SELECT A.IDTICKET,
                   A.IDOPERADOR,
                   A.FECHA,
                   A.IDPAIS_ORIGEN,
                   A.IDAFILIADO,
                   A.TELEFONO,
                   A.IDESTADO,
                   I.DESCRIPCION as ESTADO,
                    A.IDPAIS_DESTINO,
                    A.IDPROVINCIA_ORIGEN,
                    A.IDPROVINCIA_DESTINO,
                    A.IDCIUDAD_ORIGEN,
                    A.IDCIUDAD_DESTINO,
                    A.IDLOCALIDAD_DESTINO,
                    H.nombre LOCALIDAD_DESTINO_NOMBRE,
                    A.IDLOCALIDAD_ORIGEN,                    
                    G.nombre LOCALIDAD_ORIGEN_NOMBRE,                   
                    A.CALLE_DESTINO,
                    A.CALLE_ORIGEN,
                    A.OBJECTHASH,
                    A.TIPO_TICKET,
                    B.PATENTE,
                    B.POLIZA,
                    B.MARCA,
                    B.MODELO,
                    rtrim(rtrim((UPPER(B.APELLIDO) || '', ''|| UPPER(B.NOMBRE))),'','') NOMBRE_AFILIADO,
                    rtrim(rtrim((UPPER(C.APELLIDO) || '', ''|| UPPER(C.NOMBRE))),'','') NOMBRE_OPERADOR,
                    F.NOMBRE NOMBRE_EMPRESA,
                    B.FECHADESDE,
                    B.FECHAHASTA,
                    A.OKAFILIADO,
                    A.CANT_TICKETS_AFIL,
                    A.IDCOLOR,
                    A.IDPROBLEMA,
                    A.UBICACION_DESCR,
                    A.DEMORA_EST,
                    B.CATEGORIA,
                    J.NOMBRE AS CATEGORIA_NOMBRE,
                    A.URL_ORIGEN,
                    A.URL_DESTINO
              FROM TICKETS A,
                   AFILIADOS B,
                   OPERADORES C,
                   EMPRESAS F,
                   UBICACIONES_VW G,
                   UBICACIONES_VW H,
                   ESTADOS I,
                   CATAGORIAS J
              WHERE a.idafiliado = b.idafiliado (+) and 
                    a.idoperador = c.idoperador and
                    b.idempresa = f.idempresa (+) and
                    a.idlocalidad_origen = g.idlocalidad(+) and
                    a.idlocalidad_destino = h.idlocalidad(+) and
                    a.idestado = i.idestado and
                    b.categoria = j.codigo (+)';
            
  -- ID
  IF (P_ID <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDTICKET=' || P_ID;
  END IF;    
  
  IF (P_IDOPERADOR <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDOPERADOR=' || P_IDOPERADOR;
  END IF;  
  
  IF (P_IDAFILIADO <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDAFILIADO=' || P_IDAFILIADO;
  END IF;     
  
  IF (P_CIUDAD_ORIGEN <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDPROVINCIA_ORIGEN=' || P_CIUDAD_ORIGEN;
  END IF;  
  
  IF (P_CIUDAD_DESTINO <> INT_NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'A.IDCIUDAD_DESTINO=' || P_CIUDAD_DESTINO;
  END IF;  

  
  IF (P_SEARCH IS NOT NULL) THEN
      strsql:=  strsql || IASSIST_PKG.WHERECLAUSE(isWhere) || 'UPPER(a.IDOPERADOR || A.IDTICKET || NVL(B.NOMBRE,'''') || NVL(B.APELLIDO,'''') || NVL(B.POLIZA,'''') || NVL(B.PATENTE,'''') || C.APELLIDO || C.NOMBRE || I.DESCRIPCION || J.NOMBRE) LIKE UPPER(''%'||P_SEARCH||'%'')';
  END IF;
  
  -- Order by clause
  IF (P_ORDER_BY IS NOT NULL) THEN  
    strsql:= strsql || P_ORDER_BY;
  END IF;  
  
  IF(P_IS_PAGED=1) THEN
    
    strsql:= IASSIST_PKG.SET_PAGE_SQL (strsql, P_PAGE_START, P_PAGE_SIZE);
  
  END IF;
  
  
  Open R_CURSOR for strsql;
  
  END LIST_TICKET;

  -- Tickets
  PROCEDURE CREATE_TICKET (
    P_ID OUT tickets.idticket%TYPE,
    P_IDOPERADOR IN tickets.idoperador%TYPE,
    P_ID_PAIS_ORIGEN IN tickets.idpais_origen%TYPE,
    P_IDAFILIADO IN tickets.idafiliado%TYPE,
    P_TELEFONO IN tickets.telefono%TYPE,
    P_IDESTADO IN tickets.idestado%TYPE,
    P_ID_PAIS_DESTINO IN tickets.idpais_destino%TYPE,
    P_ID_PROV_ORIGEN IN tickets.idprovincia_origen%TYPE,
    P_ID_PROV_DEST IN tickets.idprovincia_destino%TYPE,
    P_CIUDAD_ORIGEN IN tickets.idciudad_origen%TYPE,
    P_CIUDAD_DEST IN tickets.idciudad_destino%TYPE,
    P_OBJECTHASH IN PRESTADORES.objecthash%TYPE,
    P_CALLE_ORIGEN IN tickets.calle_origen%TYPE,
    P_CALLE_DESTINO IN tickets.calle_destino%TYPE,
    P_IDLOCALIDA_ORIGEN IN tickets.idlocalidad_origen%TYPE,
    P_IDLOCALIDA_DESTINO IN tickets.idlocalidad_destino%TYPE,
    P_TIPO_TICKET IN tickets.tipo_ticket%TYPE,
    P_OKAFILIADO IN tickets.okafiliado%TYPE,
    P_CANT_TICKETS_AFIL in tickets.cant_tickets_afil%TYPE,
    P_IDCOLOR in tickets.idcolor%TYPE,
    P_IDPROBLEMA in tickets.idproblema%TYPE,
    P_UBICACION_DESCR IN tickets.ubicacion_descr%TYPE,
    P_DEMORA_EST In tickets.demora_est%TYPE,
    P_URL_ORIGEN In tickets.url_origen%TYPE,
    P_URL_DESTINO In tickets.url_destino%TYPE
  )
   IS
   ID_INSERT NUMBER;
  BEGIN
  
    ID_INSERT:= SEQ_TICKETS.NEXTVAL;
    
    INSERT INTO TICKETS 
    (
      tickets.idticket,
      tickets.idoperador,
      tickets.fecha,
      tickets.idpais_origen,
      tickets.idafiliado,
      tickets.telefono,
      tickets.idestado,
      tickets.idpais_destino,
      tickets.idprovincia_origen,
      tickets.idprovincia_destino,
      tickets.idciudad_origen,
      tickets.idciudad_destino,
      tickets.objecthash,
      tickets.calle_origen,
      tickets.calle_destino,
      tickets.idlocalidad_origen,
      tickets.idlocalidad_destino,
      tickets.tipo_ticket,
      tickets.okafiliado,
      tickets.cant_tickets_afil,
      tickets.idcolor,
      tickets.idproblema,
      tickets.ubicacion_descr,
      tickets.demora_est,
      tickets.url_origen,
      tickets.url_destino
    )
    VALUES 
    (
      ID_INSERT,
      P_IDOPERADOR,
      SYSDATE,
      decode(P_ID_PAIS_ORIGEN,INT_NULL,null,P_ID_PAIS_ORIGEN),
      decode(P_IDAFILIADO,INT_NULL,null,P_IDAFILIADO),
      P_TELEFONO,
      decode(P_IDESTADO,INT_NULL,null,P_IDESTADO),
      decode(P_ID_PAIS_DESTINO,INT_NULL,null,P_ID_PAIS_DESTINO),
      decode(P_ID_PROV_ORIGEN,INT_NULL,null,P_ID_PROV_ORIGEN),
      decode(P_ID_PROV_DEST,INT_NULL,null,P_ID_PROV_DEST),
      P_CIUDAD_ORIGEN,
      P_CIUDAD_DEST,
      P_OBJECTHASH,
      P_CALLE_ORIGEN,
      P_CALLE_DESTINO,
      decode(P_IDLOCALIDA_ORIGEN,INT_NULL,null,P_IDLOCALIDA_ORIGEN),
      decode(P_IDLOCALIDA_DESTINO,INT_NULL,null,P_IDLOCALIDA_DESTINO),
      P_TIPO_TICKET,
      P_OKAFILIADO,
      P_CANT_TICKETS_AFIL,
      P_IDCOLOR,
      P_IDPROBLEMA,
      P_UBICACION_DESCR,
      P_DEMORA_EST,
      P_URL_ORIGEN,
      P_URL_DESTINO
    );
    
    P_ID:= ID_INSERT;
    
  END CREATE_TICKET;
  
  PROCEDURE MODIFY_TICKET 
  (
    P_ID IN tickets.idticket%TYPE,
    P_IDOPERADOR IN tickets.idoperador%TYPE,
    P_IDAFILIADO IN tickets.idafiliado%TYPE,
    P_ID_PAIS_ORIGEN IN tickets.idpais_origen%TYPE,
    P_ID_PROV_ORIGEN IN tickets.idprovincia_origen%TYPE,
    P_CIUDAD_ORIGEN IN tickets.idciudad_origen%TYPE,
    P_ID_PAIS_DEST IN tickets.idpais_destino%TYPE,
    P_ID_PROV_DEST IN tickets.idprovincia_destino%TYPE,
    P_CIUDAD_DEST IN tickets.idciudad_destino%TYPE,
    P_TELEFONO IN tickets.telefono%TYPE,
    P_IDESTADO IN tickets.idestado%TYPE,
    P_CALLE_ORIGEN IN tickets.calle_origen%TYPE,
    P_CALLE_DESTINO IN tickets.calle_destino%TYPE,
    P_ID_LOCALIDAD_DESTINO IN tickets.idprovincia_destino%TYPE,
    P_ID_LOCALIDAD_ORIGEN IN tickets.idlocalidad_origen%TYPE, 
    P_OBJECTHASH IN PRESTADORES.objecthash%TYPE,
    P_TIPO_TICKET IN tickets.tipo_ticket%TYPE,
    P_OKAFILIADO IN tickets.okafiliado%TYPE,
    P_CANT_TICKETS_AFIL in tickets.cant_tickets_afil%TYPE,
    P_IDCOLOR in tickets.idcolor%TYPE,
    P_IDPROBLEMA in tickets.idproblema%TYPE,
    P_UBICACION_DESCR IN tickets.ubicacion_descr%TYPE,
    P_DEMORA_EST In tickets.demora_est%TYPE,
    P_URL_ORIGEN In tickets.url_origen%TYPE,
    P_URL_DESTINO In tickets.url_destino%TYPE,
    P_AFFECTED_ROWS OUT number
  )
  IS
  BEGIN
  
    UPDATE TICKETS 
      SET 
      tickets.idoperador =  decode(P_IDOPERADOR,INT_NULL,null,P_IDOPERADOR),
      tickets.idafiliado =  decode(P_IDAFILIADO,INT_NULL,null,P_IDAFILIADO),
      tickets.idpais_origen =  decode(P_ID_PAIS_ORIGEN,INT_NULL,null,P_ID_PAIS_ORIGEN),
      tickets.idprovincia_origen =  decode(P_ID_PROV_ORIGEN,INT_NULL,null,P_ID_PROV_ORIGEN),
      tickets.idciudad_origen =  decode(P_CIUDAD_ORIGEN,INT_NULL,null,P_CIUDAD_ORIGEN),
      tickets.idpais_destino =  decode(P_ID_PAIS_DEST,INT_NULL,null,P_ID_PAIS_DEST),
      tickets.idprovincia_destino =  decode(P_ID_PROV_DEST,INT_NULL,null,P_ID_PROV_DEST),
      tickets.idciudad_destino =  decode(P_CIUDAD_DEST,INT_NULL,null,P_CIUDAD_DEST),      
      tickets.telefono = P_TELEFONO,
      tickets.idestado = decode(P_IDESTADO,INT_NULL,null,P_IDESTADO),
      tickets.calle_destino = P_CALLE_DESTINO,
      tickets.calle_origen = P_CALLE_ORIGEN,
      tickets.idlocalidad_origen = decode(P_ID_LOCALIDAD_ORIGEN,INT_NULL,null,P_ID_LOCALIDAD_ORIGEN),
      tickets.idlocalidad_destino = decode(P_ID_LOCALIDAD_DESTINO,INT_NULL,null,P_ID_LOCALIDAD_DESTINO),
      tickets.tipo_ticket = P_TIPO_TICKET,
      tickets.okafiliado = P_OKAFILIADO,
      tickets.cant_tickets_afil = P_CANT_TICKETS_AFIL,
      tickets.idcolor = P_IDCOLOR,
      tickets.idproblema = P_IDPROBLEMA,
      tickets.ubicacion_descr = P_UBICACION_DESCR,
      tickets.demora_est = P_DEMORA_EST,
      tickets.url_origen = P_URL_ORIGEN,
      tickets.url_destino = P_URL_DESTINO
    WHERE tickets.idticket = P_ID and tickets.objecthash = P_OBJECTHASH;
    
    P_AFFECTED_ROWS:= sql%rowcount;
  
  END MODIFY_TICKET;
  
  PROCEDURE DELETE_TICKET_PRESTADOR (
    P_ID IN TICKET_PRESTADORES.IDTICKETPRESTADOR%TYPE
  )
  IS
  BEGIN
    DELETE TICKET_PRESTADORES 
    WHERE TICKET_PRESTADORES.IDTICKETPRESTADOR = P_ID;     
  END DELETE_TICKET_PRESTADOR;
  
  
  PROCEDURE DELETE_PRESTADOR_BY_TICKET (
    P_IDTICKET IN TICKET_PRESTADORES.IDTICKETPRESTADOR%TYPE
  )
  IS
  BEGIN
  
    DELETE TICKET_PRESTADORES 
    WHERE IDTICKET = P_IDTICKET;     
  
  END DELETE_PRESTADOR_BY_TICKET;
  

  
  -- Relacion ticket-prestador.
PROCEDURE CREATE_TICKET_PRESTADOR (
    P_ID OUT TICKET_PRESTADORES.IDTICKETPRESTADOR%TYPE,
    P_IDTICKET IN NUMBER, 
    P_IDPRESTADOR IN NUMBER,
    P_IDTIPOSERVICIO IN NUMBER,
    P_OBJECTHASH IN PRESTADORES.objecthash%TYPE,
    P_COMENTARIOS IN TICKET_PRESTADORES.COMENTARIOS%TYPE,
    P_KILOMETROS IN TICKET_PRESTADORES.KILOMETROS%TYPE,
    P_COSTO IN TICKET_PRESTADORES.COSTO%TYPE,
    P_IDPAIS_ORIGEN IN TICKET_PRESTADORES.IDPAIS_ORIGEN%TYPE, 
	P_IDPAIS_DESTINO IN TICKET_PRESTADORES.IDPAIS_DESTINO%TYPE, 
	P_IDPROVINCIA_ORIGEN IN TICKET_PRESTADORES.IDPROVINCIA_ORIGEN%TYPE, 
	P_IDPROVINCIA_DESTINO IN TICKET_PRESTADORES.IDPROVINCIA_DESTINO%TYPE, 
	P_IDCIUDAD_ORIGEN IN TICKET_PRESTADORES.IDCIUDAD_ORIGEN%TYPE, 
	P_IDCIUDAD_DESTINO IN TICKET_PRESTADORES.IDCIUDAD_DESTINO%TYPE, 
	P_CALLE_ORIGEN IN TICKET_PRESTADORES.CALLE_ORIGEN%TYPE, 
	P_IDLOCALIDAD_ORIGEN IN TICKET_PRESTADORES.IDLOCALIDAD_ORIGEN%TYPE, 
	P_IDLOCALIDAD_DESTINO IN TICKET_PRESTADORES.IDLOCALIDAD_DESTINO%TYPE, 
	P_CALLE_DESTINO IN TICKET_PRESTADORES.CALLE_DESTINO%TYPE,
    P_IDESTADO IN TICKET_PRESTADORES.IDESTADO%TYPE,
    P_IDTICKETPRESTADOR_RETRABAJO IN TICKET_PRESTADORES.IDTICKETPRESTADOR_RETRABAJO%TYPE,
	P_PATENTE IN TICKET_PRESTADORES.PATENTE%TYPE, 
	P_NOMBRE_CHOFER IN TICKET_PRESTADORES.NOMBRE_CHOFER%TYPE,
    P_IDFINALIZACION IN TICKET_PRESTADORES.IDFINALIZACION%TYPE,
    P_DEMORA_EST In TICKET_PRESTADORES.DEMORA_EST%TYPE,
    P_DEMORA_REAL In TICKET_PRESTADORES.DEMORA_REAL%TYPE,
    P_IDTIPOPRESTACION In TICKET_PRESTADORES.IDTIPOPRESTACION%TYPE
  )
   IS
   ID_INSERT NUMBER;
  BEGIN
  
    ID_INSERT:= SEQ_TICKETS.NEXTVAL;
    
    INSERT
    INTO TICKET_PRESTADORES
      (
        IDTICKETPRESTADOR,
        IDTICKET,
        IDPRESTADOR,
        IDTIPOSERVICIO,
        OBJECTHASH,
        COMENTARIOS,
        KILOMETROS,
        COSTO,
        IDPAIS_ORIGEN, 
        IDPAIS_DESTINO, 
        IDPROVINCIA_ORIGEN, 
        IDPROVINCIA_DESTINO, 
        IDCIUDAD_ORIGEN, 
        IDCIUDAD_DESTINO,
        CALLE_ORIGEN,
        IDLOCALIDAD_ORIGEN,
        IDLOCALIDAD_DESTINO,
        CALLE_DESTINO,
        IDESTADO,
        IDTICKETPRESTADOR_RETRABAJO,
        PATENTE,
        NOMBRE_CHOFER,
        IDFINALIZACION,
        DEMORA_EST,
        DEMORA_REAL,
        IDTIPOPRESTACION
      )
      VALUES
      (
        ID_INSERT,
        P_IDTICKET,
        P_IDPRESTADOR,
        P_IDTIPOSERVICIO,
        P_OBJECTHASH,
        P_COMENTARIOS,
        P_KILOMETROS,
        P_COSTO,
        P_IDPAIS_ORIGEN, 
        P_IDPAIS_DESTINO, 
        P_IDPROVINCIA_ORIGEN, 
        P_IDPROVINCIA_DESTINO, 
        P_IDCIUDAD_ORIGEN, 
        P_IDCIUDAD_DESTINO,
        P_CALLE_ORIGEN,
        P_IDLOCALIDAD_ORIGEN,
        P_IDLOCALIDAD_DESTINO,
        P_CALLE_DESTINO,
        P_IDESTADO,
        P_IDTICKETPRESTADOR_RETRABAJO,
        P_PATENTE,
        P_NOMBRE_CHOFER,
        P_IDFINALIZACION,
        P_DEMORA_EST,
        P_DEMORA_REAL,
        P_IDTIPOPRESTACION
      );
      
      P_ID:= ID_INSERT;
  
  END CREATE_TICKET_PRESTADOR;
  
  PROCEDURE MODIFY_TICKET_PRESTADOR (
    P_ID IN TICKET_PRESTADORES.IDTICKETPRESTADOR%TYPE,
    P_IDTICKET IN NUMBER, 
    P_IDPRESTADOR IN NUMBER,
    P_IDTIPOSERVICIO IN NUMBER,
    P_OBJECTHASH IN PRESTADORES.objecthash%TYPE,
    P_COMENTARIOS IN TICKET_PRESTADORES.COMENTARIOS%TYPE,
    P_KILOMETROS IN TICKET_PRESTADORES.KILOMETROS%TYPE,
    P_COSTO IN TICKET_PRESTADORES.COSTO%TYPE,
    P_IDPAIS_ORIGEN IN TICKET_PRESTADORES.IDPAIS_ORIGEN%TYPE, 
	P_IDPAIS_DESTINO IN TICKET_PRESTADORES.IDPAIS_DESTINO%TYPE, 
	P_IDPROVINCIA_ORIGEN IN TICKET_PRESTADORES.IDPROVINCIA_ORIGEN%TYPE, 
	P_IDPROVINCIA_DESTINO IN TICKET_PRESTADORES.IDPROVINCIA_DESTINO%TYPE, 
	P_IDCIUDAD_ORIGEN IN TICKET_PRESTADORES.IDCIUDAD_ORIGEN%TYPE, 
	P_IDCIUDAD_DESTINO IN TICKET_PRESTADORES.IDCIUDAD_DESTINO%TYPE, 
	P_CALLE_ORIGEN IN TICKET_PRESTADORES.CALLE_ORIGEN%TYPE, 
	P_IDLOCALIDAD_ORIGEN IN TICKET_PRESTADORES.IDLOCALIDAD_ORIGEN%TYPE, 
	P_IDLOCALIDAD_DESTINO IN TICKET_PRESTADORES.IDLOCALIDAD_DESTINO%TYPE, 
	P_CALLE_DESTINO IN TICKET_PRESTADORES.CALLE_DESTINO%TYPE,
    P_IDESTADO IN TICKET_PRESTADORES.IDESTADO%TYPE,
    P_IDTICKETPRESTADOR_RETRABAJO IN TICKET_PRESTADORES.IDTICKETPRESTADOR_RETRABAJO%TYPE,
	P_PATENTE IN TICKET_PRESTADORES.PATENTE%TYPE, 
	P_NOMBRE_CHOFER IN TICKET_PRESTADORES.NOMBRE_CHOFER%TYPE,
    P_IDFINALIZACION IN TICKET_PRESTADORES.IDFINALIZACION%TYPE,
    P_DEMORA_EST In TICKET_PRESTADORES.DEMORA_EST%TYPE,
    P_DEMORA_REAL In TICKET_PRESTADORES.DEMORA_REAL%TYPE,
    P_IDTIPOPRESTACION In TICKET_PRESTADORES.IDTIPOPRESTACION%TYPE,
    P_AFFECTED_ROWS OUT number
  )
   IS
   BEGIN
     UPDATE TICKET_PRESTADORES
    SET TICKET_PRESTADORES.IDTICKET = P_IDTICKET,
        TICKET_PRESTADORES.IDPRESTADOR = P_IDPRESTADOR,
        TICKET_PRESTADORES.IDTIPOSERVICIO = P_IDTIPOSERVICIO,
        TICKET_PRESTADORES.COMENTARIOS = P_COMENTARIOS,
        TICKET_PRESTADORES.KILOMETROS = P_KILOMETROS,
        TICKET_PRESTADORES.COSTO = P_COSTO,
        TICKET_PRESTADORES.IDPAIS_ORIGEN = P_IDPAIS_ORIGEN, 
        TICKET_PRESTADORES.IDPAIS_DESTINO = P_IDPAIS_DESTINO, 
        TICKET_PRESTADORES.IDPROVINCIA_ORIGEN = P_IDPROVINCIA_ORIGEN, 
        TICKET_PRESTADORES.IDPROVINCIA_DESTINO = P_IDPROVINCIA_DESTINO, 
        TICKET_PRESTADORES.IDCIUDAD_ORIGEN = P_IDCIUDAD_ORIGEN, 
        TICKET_PRESTADORES.IDCIUDAD_DESTINO = P_IDCIUDAD_DESTINO,
        TICKET_PRESTADORES.CALLE_ORIGEN = P_CALLE_ORIGEN,
        TICKET_PRESTADORES.IDLOCALIDAD_ORIGEN = P_IDLOCALIDAD_ORIGEN,
        TICKET_PRESTADORES.IDLOCALIDAD_DESTINO = P_IDLOCALIDAD_DESTINO,
        TICKET_PRESTADORES.CALLE_DESTINO = P_CALLE_DESTINO,
        TICKET_PRESTADORES.IDESTADO = P_IDESTADO,
        TICKET_PRESTADORES.IDTICKETPRESTADOR_RETRABAJO = P_IDTICKETPRESTADOR_RETRABAJO,
        TICKET_PRESTADORES.PATENTE = P_PATENTE,
        TICKET_PRESTADORES.NOMBRE_CHOFER = P_NOMBRE_CHOFER,
        TICKET_PRESTADORES.IDFINALIZACION = P_IDFINALIZACION,
        DEMORA_EST = P_DEMORA_EST,
        DEMORA_REAL = P_DEMORA_REAL,
        IDTIPOPRESTACION = P_IDTIPOPRESTACION
        WHERE TICKET_PRESTADORES.IDTICKETPRESTADOR = P_ID;
        
   P_AFFECTED_ROWS:= sql%rowcount;     
        
   END MODIFY_TICKET_PRESTADOR;
  
  PROCEDURE LIST_PRESTADORES_BY_TICKET (P_IDTICKET IN TICKET_PRESTADORES.IDTICKET%TYPE,
                                        R_CURSOR OUT tyRefCursor)
  IS
  BEGIN
      
      OPEN R_CURSOR FOR
      SELECT A.IDTICKETPRESTADOR,
              A.IDTICKET,
              A.IDPRESTADOR,
              A.IDTIPOSERVICIO,
              A.OBJECTHASH,
              A.COMENTARIOS,
              A.KILOMETROS,
              A.COSTO,
              B.NOMBRE NOMBRE_PRESTADOR,
              D.DESCRIPCION TIPOSERVICIO,
              A.IDPAIS_ORIGEN, 
              A.IDPAIS_DESTINO, 
              A.IDPROVINCIA_ORIGEN, 
              A.IDPROVINCIA_DESTINO, 
              A.IDCIUDAD_ORIGEN, 
              A.IDCIUDAD_DESTINO,
              A.CALLE_ORIGEN,
              A.IDLOCALIDAD_ORIGEN,
              A.IDLOCALIDAD_DESTINO,
              A.CALLE_DESTINO,
              A.IDESTADO,
              A.IDTICKETPRESTADOR_RETRABAJO,
              A.PATENTE,
              A.NOMBRE_CHOFER,
              E.NOMBRE AS LOCALIDAD_ORIGEN_NOMBRE,
              F.NOMBRE AS LOCALIDAD_DESTINO_NOMBRE,
              A.IDFINALIZACION,
              A.DEMORA_EST,
              A.DEMORA_REAL,
              A.IDTIPOPRESTACION,
              G.CODIGO AS CODIGO_TIPOPRESTACION
      FROM TICKET_PRESTADORES A, PRESTADORES B, TIPOSERVICIOS D, UBICACIONES_VW E, UBICACIONES_VW F, TIPOPRESTACIONES G
      WHERE IDTICKET = P_IDTICKET
      AND A.IDPRESTADOR = B.IDPRESTADOR (+)
      AND A.IDTIPOSERVICIO = D.IDTIPOSERVICIO (+)
      AND A.IDLOCALIDAD_ORIGEN = E.IDLOCALIDAD (+)
      AND A.IDLOCALIDAD_DESTINO = F.IDLOCALIDAD (+)
      AND A.IDTIPOPRESTACION = G.IDTIPOPRESTACION (+)
      ORDER BY A.IDTICKETPRESTADOR DESC;
      
  END LIST_PRESTADORES_BY_TICKET;
  
  
                                   
PROCEDURE LIST_TICKET_TRACK_BY_TICKET(P_IDTICKET IN TICKET_TRACK.IDTICKET%TYPE, R_CURSOR OUT tyRefCursor)
  IS
  BEGIN
  
   OPEN R_CURSOR FOR
      SELECT A.IDTICKET_TRACK,
              A.IDTICKET,
              A.FECHA_HORA,
              A.IDOPERADOR,
              A.IDESTADO,
              rtrim(rtrim((UPPER(B.APELLIDO) || ', '|| UPPER(B.NOMBRE))),',') NOMBRE_OPERADOR,
              C.DESCRIPCION AS ESTADO
      FROM TICKET_TRACK A, OPERADORES B, ESTADOS C
      WHERE IDTICKET = P_IDTICKET
      AND A.IDOPERADOR = B.IDOPERADOR (+)
      AND A.IDESTADO = C.IDESTADO (+)
      AND 'CASO' = C.GRUPO (+)
      ORDER BY A.IDTICKET_TRACK DESC;
  
  END LIST_TICKET_TRACK_BY_TICKET;

  PROCEDURE CREATE_TICKET_TRACK (
      P_ID OUT ticket_track.idticket_track%TYPE,
      P_IDTICKET IN ticket_track.idticket%TYPE,
      P_IDOPERADOR IN ticket_track.idoperador%TYPE,
      P_IDESTADO IN ticket_track.idestado%TYPE,
      P_OBJECTHASH IN ticket_track.objecthash%TYPE
    )
  IS
   ID_INSERT NUMBER;
  BEGIN
  
    ID_INSERT:= SEQ_TICKET_TRACK.NEXTVAL;
    
    INSERT
    INTO TICKET_TRACK
      (
        IDTICKET_TRACK,
        IDTICKET,
        FECHA_HORA,
        IDOPERADOR,
        IDESTADO,
        OBJECTHASH
      )
      VALUES
      (
        ID_INSERT,
        P_IDTICKET,
        SYSDATE,
        P_IDOPERADOR,
        P_IDESTADO,
        P_OBJECTHASH
      );
      
      P_ID:= ID_INSERT;
  
  END CREATE_TICKET_TRACK;
  
  
END TICKET_PKG;

/
