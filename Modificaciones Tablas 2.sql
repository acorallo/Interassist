-- inserta finalizaciones Prestaciones

insert into estados (idestado, descripcion, grupo)
values (13, 'Cancela Afiliado','FINAL_PREST');


insert into estados (idestado, descripcion, grupo)
values (14, 'Cancela Prestador','FINAL_PREST');


insert into estados (idestado, descripcion, grupo)
values (15, 'Asistencia Ok','FINAL_PREST');

commit;



-- Agregar Campo Finalizacion a la prestacion para guardar Cancela Afiliado, Cancela Prestador y Asistencia OK
ALTER TABLE TICKET_PRESTADORES ADD (IDFINALIZACION NUMBER);

-- constraint del estado de la prestación que no tenía
ALTER TABLE TICKET_PRESTADORES ADD CONSTRAINT "TICKET_PREST_ESTADO_FK" FOREIGN KEY ("IDESTADO")
	  REFERENCES "IASSIST"."ESTADOS" ("IDESTADO") ENABLE;
      
-- constraint de la finalización de la prestación      
ALTER TABLE TICKET_PRESTADORES ADD CONSTRAINT "TICKET_PREST_FINALIZA_FK" FOREIGN KEY ("IDFINALIZACION")
	  REFERENCES "IASSIST"."ESTADOS" ("IDESTADO") ENABLE;
            
-- agregar los campos OK Afiliado S/N y Cantidad de tickets
ALTER TABLE TICKETS ADD (OKAFILIADO VARCHAR2(1) DEFAULT 'N' NOT NULL );            

ALTER TABLE TICKETS ADD (CANT_TICKETS_AFIL NUMBER);



      

