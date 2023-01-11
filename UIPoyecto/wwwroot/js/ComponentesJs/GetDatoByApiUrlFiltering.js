export default async function GetObjectDataByFilter(url, varName, varValue) {
    const params = new URLSearchParams();
    params.append(varName, varValue);
    url = url + `?${params}`;
    let response = await fetch(url, {
        method: "GET",
        headers: {
            'Content-Type': "application/json; charset = utf-8",
            'Accept': "*/*"
        }
    });

    response = await response.json();
    return response;
}