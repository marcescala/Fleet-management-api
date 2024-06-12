# FLEET MANAGEMENT

## Índice


* [1. Resumen del proyecto](#2-resumen-del-proyecto)
* [2. Herramientas](#3-herramientas)



## 1. Resumen del proyecto

En este proyecto se contruyó la API REST de un Fleet Management Software para consultar las ubicaciones de los vehículos de una empresa de taxis en Beijing, China.

Con las ubicaciones de casi 10 mil taxis. Se aplicaron técnicas para almacenar y consultar esta información, usando PostgreSQL.

Se decoumento los endpoints de la API en Swagger.

## 2. Herramientas
### Uso de lenguaje C#
Se creó un proyecto Web API en C# con la plantilla "API con controladores", también se usó Entity Framework, un ORM que simplifica el acceso y manipulación de bases de datos.  

### Modelamiento de datos
Se usó vercel Postgresql, se creó tablas en la base de datos para almacenar la información entregada. Te recomendamos entonces crear dos tablas, una para almacenar la información de taxis y otra para almacenar la información de ubicaciones. Deberás definir las columnas de cada tabla de acuerdo a la información entregada.
