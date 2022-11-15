export default function CreateDataList(DataSet = [], UL, TableFunction, colums) {
    UL.innerText = "";

    DataSet.forEach((item, index) => {
        const row = document.createElement("li");
        for (var prop in item) {
            const ld = document.createElement("div");
            ld.innerText = item[prop];
            row.append(ld);
        }

        const tdAction = document.createElement("div");
        const btnTable = document.createElement("a");
        btnTable.className = "link";
        btnTable.href = "#";
        btnTable.innerText = "Ver más...";
        btnTable.onclick = () => {
            TableFunction(item);
        }
        tdAction.append(btnTable);
        row.append(tdAction);
        row.classList.add('container', colums);
        UL.append(row);
    });
}