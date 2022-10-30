export default function CreateTable(DataSet = [], Table, TableFunction) {
    const thead = Table.querySelector("thead");
    const tbody = Table.querySelector("tbody");
    tbody.innerText = "";
    thead.innerText = "";

    DataSet.forEach((item, index) => {
        const row = document.createElement("tr");
        for (var prop in item) {
            if (index == 0) {
                const th = document.createElement("th");
                th.innerText = prop;
                thead.append(th);
            }
            const td = document.createElement("td");
            td.innerText = item[prop];
            row.append(td);
        }
        if (index == 0) {
            const th = document.createElement("th");
            th.innerText = "Acción";
            thead.append(th);
        }
        const tdAction = document.createElement("td");
        const btnTable = document.createElement("input");
        btnTable.className = "Link-Button";
        btnTable.type = "button";
        btnTable.value = "Edit";
        btnTable.onclick = () => {
            TableFunction(item);
        }
        tdAction.append(btnTable);
        row.append(tdAction);
        tbody.append(row);
    });
}




