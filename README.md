# PoyectoAspNet
Proyecto de graduación - Poyecto


incluir componentes a las paguinas a traves de:


--=-------Extraer Datos de los controladores:

 import GetObjectData from "../js/ComponentesJs/GetDatosByApiUrlComponent.js";

let url = "../api/Alimento/GetAlimentos"    --> url de la api de ejemplo

let variableName = await GetObjectData(url);


--=-------Guardar Datos a los controladores:

 import SaveObjectData from "../js/ComponentesJs/PutDatoByApiUrlComponent.js";

let url = '../api/Alimento/SaveAlimento'    --> url de la api de ejemplo

const alimentoEjemplo = { crearObjeto con propiedades }

let respuestaDeGuardado = await SaveObjectData(url, alimentoEjemplo);
