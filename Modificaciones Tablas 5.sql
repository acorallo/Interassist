

ALTER TABLE IASSIST.TICKETS
ADD (UBICACION_DESCR VARCHAR2(1024));


ALTER TABLE IASSIST.TICKETS
ADD (DEMORA_EST VARCHAR2(20));

ALTER TABLE IASSIST.TICKET_PRESTADORES
ADD (DEMORA_EST VARCHAR2(20));

ALTER TABLE IASSIST.TICKET_PRESTADORES
ADD (DEMORA_REAL VARCHAR2(20));


UPDATE IASSIST.TICKET_PRESTADORES
SET DEMORA_EST = DEMORA;

COMMIT;

ALTER TABLE IASSIST.TICKET_PRESTADORES
DROP COLUMN DEMORA;


CREATE TABLE IASSIST.TIPOPRESTACIONES 
(
  IDTIPOPRESTACION NUMBER NOT NULL 
, CODIGO VARCHAR2(5)
, DESCRIPCION VARCHAR2(255) 
, CONSTRAINT TIPOPRESTACIONES_PK PRIMARY KEY 
  (
    IDTIPOPRESTACION 
  )
  ENABLE 
);

ALTER TABLE IASSIST.TIPOPRESTACIONES ADD OBJECTHASH VARCHAR2(50 BYTE);


ALTER TABLE IASSIST.TICKET_PRESTADORES
ADD (IDTIPOPRESTACION NUMBER);


ALTER TABLE IASSIST.TICKET_PRESTADORES ADD 
CONSTRAINT "TICKET_PREST_TIPOPREST_FK" FOREIGN KEY ("IDTIPOPRESTACION")
	  REFERENCES "IASSIST"."TIPOPRESTACIONES" ("IDTIPOPRESTACION") ENABLE;



INSERT INTO TIPOPRESTACIONES (IDTIPOPRESTACION, CODIGO, DESCRIPCION)
VALUES (1,'LIV','Liviano');

INSERT INTO TIPOPRESTACIONES (IDTIPOPRESTACION, CODIGO, DESCRIPCION)
VALUES (2,'SP1','SP1');


INSERT INTO TIPOPRESTACIONES (IDTIPOPRESTACION, CODIGO, DESCRIPCION)
VALUES (3,'SP2','SP2');


INSERT INTO TIPOPRESTACIONES (IDTIPOPRESTACION, CODIGO, DESCRIPCION)
VALUES (4,'PS1','PS1');

INSERT INTO TIPOPRESTACIONES (IDTIPOPRESTACION, CODIGO, DESCRIPCION)
VALUES (5,'PS2','PS2');

COMMIT;

