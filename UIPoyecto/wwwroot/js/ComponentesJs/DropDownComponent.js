export default function CreateDropdown(dataset = [],
    Select,
    Display = "",
    Value = "",
    SelectedFunction) {
    //if (SelectedFunction) {
    //    Select.onchange = SelectedFunction(Select.Value);
    //}

    dataset.forEach((item, index) => {
        const options = document.createElement("option");
        options.innerText = item[Display];
        options.value = item[Value];
        Select.append(options);
    });
}