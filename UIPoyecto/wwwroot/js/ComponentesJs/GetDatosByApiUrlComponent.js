export default async function GetObjectData(url) {
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