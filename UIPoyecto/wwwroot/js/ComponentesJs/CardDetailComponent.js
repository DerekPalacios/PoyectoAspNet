export default function CreateDetailCard(DataSet = [], UL, IdSpan, id) {
    UL.innerText = "";

    IdSpan.innerText = id;

    DataSet.forEach((item, index) => {
        for (var prop in item) {

            //if (index == 0) {
            //    const th = document.createElement("span");
            //    th.innerText = prop[0].toUpperCase() + prop.substr(1);
            //    frow.append(th);
            //}
            const row = document.createElement("li");

            const propertyName = document.createElement("span");
            propertyName.innerText = prop[0].toUpperCase() + prop.substr(1) + ': ';
            row.append(propertyName);
            const ld = document.createElement("span");
            ld.innerText = item[prop];
            row.append(ld);

            UL.append(row);
        };
    });
}