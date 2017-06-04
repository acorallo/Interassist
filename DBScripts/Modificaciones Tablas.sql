
/*
Tabla: ESTADOS
Agregar campo llamada Grupo, para agrupar los códigos de estado que aplican a un campo. La tabla seguirá teniendo el IDESTADO como clave primaria, este solo será un campo más, que indica para que Grupo o Campo se utilizará ese Estado. (Se usarán para tener en la misma tabla el maestro de estados del ticket y de la prestación)
*/

ALTER TABLE ESTADOS 
ADD (GRUPO VARCHAR2(20) NOT NULL);


/*
Tabla TICKETS:
Se mantendrán igual los campso de las direcciones Origen y Destino, solamente se quitarán los campso Altura_origen y Altura_destino. La altura se cargará en el mismo campo que la calle.

Se quita el campo IDPROBLEMA, porque pasa para las Prestaciones

El campo TIPO_TICKET pasará a tener el valor Vehículo, usará otra tabla maestra de Tipos de Tickets distinta a la actual. Ya que los valores que usa actualmente pasarán a ser valores de las Prestaciones.
*/

UPDATE TICKETS 
SET CALLE_ORIGEN = TRIM(NVL(CALLE_ORIGEN,' ') || ' ' || NVL(ALTURA_ORIGEN,' ')),
	CALLE_DESTINO = TRIM(NVL(CALLE_DESTINO,' ') || ' ' || NVL(ALTURA_DESTINO,' '));
	
UPDATE TICKETS 
SET ALTURA_ORIGEN = NULL,
	ALTURA_DESTINO = NULL;	
	
COMMIT;
	
ALTER TABLE TICKETS 
DROP COLUMN ALTURA_ORIGEN;

ALTER TABLE TICKETS 
DROP COLUMN ALTURA_DESTINO;


ALTER TABLE TICKET_PRESTADORES
ADD (IDPROBLEMA NUMBER);

ALTER TABLE TICKET_PRESTADORES ADD CONSTRAINT "TICKET_PREST_PROBLEMA_FK" FOREIGN KEY ("IDPROBLEMA")
	  REFERENCES "IASSIST"."PROBLEMAS" ("IDPROBLEMA") ENABLE;

UPDATE TICKET_PRESTADORES A
SET IDPROBLEMA = (SELECT Z.IDPROBLEMA FROM TICKETS Z WHERE A.IDTICKET = Z.IDTICKET);

COMMIT;

ALTER TABLE TICKETS DROP CONSTRAINT TICKETS_PROBELMA_FK;

ALTER TABLE TICKETS MODIFY IDPROBLEMA NULL;

UPDATE TICKETS
SET IDPROBLEMA = NULL;

COMMIT;

ALTER TABLE TICKETS 
DROP COLUMN IDPROBLEMA;

ALTER TABLE TICKETS MODIFY IDAFILIADO NULL;

/*
Tabla TICKET_PRESTADORES

El campo IDPRESTADOR pasa a aceptar Nulos.

El campo IDTIPOSERVICIO pasará a tener solo dos valores: Asistencia / Asesoramiento (se los cargará en la tabla TIPOSERVICIOS)

Agregar el campo IDPROBLEMA, que obtendrá sus valores de la tabla PROBLEMAS. ¿Hay relación entre Tipo de Servicio y Problema?

Se agregarán los campos de la Dirección Origen y dirección Destino, con la misma estructura como hoy están en el Ticket.

Se agrega el campo IDESTADO y tendrá sus valores de la tabla ESTADOS consultando por el grupo Prestaciones

Se agregan los campos Demora, Patente y Nombre Chofer Grua.

Se agrega el campo Retrabajo.

Se mantienen los campos de KM,  Costo y Comentarios.
*/

ALTER TABLE TICKET_PRESTADORES MODIFY IDPRESTADOR NULL;

-- Por el momento ignorar
--UPDATE TIPOSERVICIOS SET ESTADO = 2;  -- Ver cuál sería el valor

ALTER TABLE TICKET_PRESTADORES ADD (
	"IDPAIS_ORIGEN" NUMBER, 
	"IDPAIS_DESTINO" NUMBER, 
	"IDPROVINCIA_ORIGEN" NUMBER, 
	"IDPROVINCIA_DESTINO" NUMBER, 
	"IDCIUDAD_ORIGEN" NUMBER, 
	"IDCIUDAD_DESTINO" NUMBER, 
	"CALLE_ORIGEN" VARCHAR2(1024 BYTE), 
	"IDLOCALIDAD_ORIGEN" NUMBER, 
	"IDLOCALIDAD_DESTINO" NUMBER, 
	"CALLE_DESTINO" VARCHAR2(1024 BYTE)
);

ALTER TABLE TICKET_PRESTADORES ADD (IDESTADO NUMBER);


ALTER TABLE TICKET_PRESTADORES ADD (
	"IDTICKETPRESTADOR_RETRABAJO" NUMBER,
	"DEMORA" VARCHAR2(20), 
	"PATENTE" VARCHAR2(20), 
	"NOMBRE_CHOFER" VARCHAR2(255)
);

ALTER TABLE TICKET_PRESTADORES ADD CONSTRAINT "TICKET_PREST_RETRABAJO_FK" FOREIGN KEY ("IDTICKETPRESTADOR_RETRABAJO")
	  REFERENCES "IASSIST"."TICKET_PRESTADORES" ("IDTICKETPRESTADOR") ENABLE;

/*
Se mantienen la tabla de OBSERVACIONES. Estas Observaciones se mostrarán en la pantalla de ticket.
*/





INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('4', 'Borrador', 'CASO');
INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('5', 'Abierto', 'CASO');
INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('6', 'Pendiente de Cierre', 'CASO');
INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('7', 'Cerrado', 'CASO');


INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('8', 'Borrador', 'PRESTACION');
INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('9', 'Pendiente Prestador', 'PRESTACION');
INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('10', 'Pendiente Asistencia', 'PRESTACION');
INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('11', 'Pendiente Cierre', 'PRESTACION');
INSERT INTO "IASSIST"."ESTADOS" (IDESTADO, DESCRIPCION, GRUPO) VALUES ('12', 'Cerrado', 'PRESTACION');



/* 
Estado de tickets, conversión:
de 1 Abierto a 5 Abierto
de 2 Cerrado a 7 Cerrado
de 3 En Curso a 4 Borrador
*/

update tickets set idestado = decode(idestado,1,5,2,7,3,4,idestado);




commit;





