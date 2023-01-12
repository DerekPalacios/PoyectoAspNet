const ddlPreInicio = document.getElementById('preinicio');

document.querySelector('#ddlLinea').onchange = e => {

    const { value: property, text: label } = e.target.selectedOptions[0]

    if(property == 1){
        const options = document.createElement("option");
        options.innerText = "aqui llego en rojo";
        options.value = 1;
        ddlPreInicio.append(options);
    }else if(property == 2){
        const options = document.createElement("option");
        options.innerText = "aqui llego en azul";
        options.value = 1;
        ddlPreInicio.append(options);
    }else if(property == 3){
        const options = document.createElement("option");
        options.innerText = "aqui llego en verde";
        options.value = 1;
        ddlPreInicio.append(options);
    }
}