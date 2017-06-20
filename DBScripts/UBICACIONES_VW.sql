--------------------------------------------------------
--  DDL for View UBICACIONES_VW
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "IASSIST"."UBICACIONES_VW" ("IDLOCALIDAD", "LOCALIDAD", "IDCIUDAD", "CIUDAD", "IDPROVINCIA", "PROVINCIA", "IDPAIS", "PAIS", "NOMBRE") AS 
  select a.idlocalidad, a.nombre as localidad, b.idciudad, b.nombre as ciudad, c.idprovincia, c.provincia, d.idpais, d.pais, a.nombre || ', ' || b.nombre || ', ' || c.provincia || ', ' || d.pais as nombre
from localidades a,  ciudades b, provincias c, paises d
where a.idciudad = b.idciudad
and b.idprovincia = c.idprovincia
and c.idpais = d.idpais
;
