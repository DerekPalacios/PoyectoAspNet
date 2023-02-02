export default function CreateDataList(DataSet = [], UL, TableFunction, colums, URL) {
    UL.innerText = "";
    const frow = document.createElement("li");
    frow.classList.add("container");
    frow.classList.add("dl-main-header");
    frow.classList.add(colums);
    var URLId = "";

    UL.append(frow);

    DataSet.forEach((item, index) => {
        const row = document.createElement("li");
        for (var prop in item) {

            if (index == 0) {
                const th = document.createElement("div");
                th.innerText = prop[0].toUpperCase() + prop.substr(1);
                frow.append(th);
            }

            if (prop.toUpperCase() == "ESTADO") {
                    const bolita = document.createElement("div");
                bolita.classList.add("squer");
                if (item[prop].toString().toUpperCase() == "TRUE") {
                    bolita.classList.add("squer-active");
                } else {
                    bolita.classList.add("squer-danger");
                }
                row.append(bolita);
            } else {
                const ld = document.createElement("div");
                ld.innerText = item[prop];
                row.append(ld);
            }

            if (prop.toUpperCase() == "ID") {
                URLId = URL + "?id=" + item[prop];
            }
        }
        if (index == 0) {
            const th = document.createElement("div");
            th.innerText = "Acción";
            frow.append(th);
        }

        const tdAction = document.createElement("div");
        const btnTable = document.createElement("a");
        btnTable.className = "link";
        btnTable.href = URLId;
        btnTable.innerText = "Detalles...";
        btnTable.onclick = () => {
            TableFunction(item);
        }
        tdAction.append(btnTable);
        row.append(tdAction);
        row.classList.add('container', colums);
        UL.append(row);
    });
}