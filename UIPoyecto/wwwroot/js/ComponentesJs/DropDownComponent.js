export default function CreateDropdown(dataset = [],
    Select,
    Display = "",
    Value = "",
    SelectedFunction) {
    if (SelectedFunction) {
        Select.onchange = SelectedFunction(Select.Value);
    }

    const options = document.createElement("option");
    options.innerText = "-Seleccione-";
    options.value = 0;
    Select.append(options);

    dataset.forEach((item, index) => {
        const options = document.createElement("option");
        options.innerText = item[Display];
        options.value = item[Value];
        Select.append(options);
    });
}