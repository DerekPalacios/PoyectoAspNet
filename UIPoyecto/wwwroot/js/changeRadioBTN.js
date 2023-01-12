const rdAlimentacion1 = document.getElementById('tipoAlimentacion1');
const rdAlimentacion2 = document.getElementById('tipoAlimentacion2');
const rdAlimentacion3 = document.getElementById('tipoAlimentacion3');
const rdFinalizacion1 = document.getElementById('finalizacion1');
const rdFinalizacion2 = document.getElementById('finalizacion2');
const rdTratamiento1 = document.getElementById('tipoTratamiento1');
const rdTratamiento2 = document.getElementById('tipoTratamiento2');
const ddlLinea = document.getElementById('ddlLinea');
const ddlTratamiento = document.getElementById('ddlTratamiento');
const txtTratamiento = document.getElementById('txtTratamiento');

rdAlimentacion1.addEventListener('click', () =>{
    if(!rdAlimentacion1.classList.contains('squer-active')){
        rdAlimentacion1.classList.toggle('squer-active');

        rdAlimentacion2.classList.remove('squer-active');
        rdAlimentacion3.classList.remove('squer-active');
        ddlLinea.value = 0;
        ddlLinea.disabled = true;

        await cargarDLPreinicio();
        await cargarDLInicio();
        await cargarDLDesarrollo();
        await cargarDLFinalizacion();
    }
});

rdAlimentacion2.addEventListener('click', () =>{
    if(!rdAlimentacion2.classList.contains('squer-active')){
        rdAlimentacion2.classList.toggle('squer-active');

        rdAlimentacion1.classList.remove('squer-active');
        rdAlimentacion3.classList.remove('squer-active');
        ddlLinea.value = 0;
        ddlLinea.disabled = true;

        await cargarDLPreinicioEtapa();
        await cargarDLInicioEtapa();
        await cargarDLDesarrolloEtapa();
        await cargarDLFinalizacionEtapa();
    }
});

rdAlimentacion3.addEventListener('click', () =>{
    if(!rdAlimentacion3.classList.contains('squer-active')){
        rdAlimentacion3.classList.toggle('squer-active');

        rdAlimentacion1.classList.remove('squer-active');
        rdAlimentacion2.classList.remove('squer-active');
        ddlLinea.disabled = false;
    }
});

rdFinalizacion1.addEventListener('click', () =>{
    if(!rdFinalizacion1.classList.contains('squer-active')){
        rdFinalizacion1.classList.toggle('squer-active');
        rdFinalizacion2.classList.toggle('squer-active');
    }
});

rdFinalizacion2.addEventListener('click', () =>{
    if(!rdFinalizacion2.classList.contains('squer-active')){
        rdFinalizacion1.classList.toggle('squer-active');
        rdFinalizacion2.classList.toggle('squer-active');
    }
});

rdTratamiento1.addEventListener('click', () =>{
    if(!rdTratamiento1.classList.contains('squer-active')){
        rdTratamiento1.classList.toggle('squer-active');
        rdTratamiento2.classList.toggle('squer-active');

        ddlTratamiento.classList.toggle('hiden');
        txtTratamiento.classList.toggle('hiden');
    }
});

rdTratamiento2.addEventListener('click', () =>{
    if(!rdTratamiento2.classList.contains('squer-active')){
        rdTratamiento1.classList.toggle('squer-active');
        rdTratamiento2.classList.toggle('squer-active');

        ddlTratamiento.classList.toggle('hiden');
        txtTratamiento.classList.toggle('hiden');
    }
});