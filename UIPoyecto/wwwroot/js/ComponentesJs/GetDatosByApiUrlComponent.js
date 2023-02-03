export default async function GetObjectData(url) {
    let response = await fetch(url, {
        method: "GET",
        headers: {
            'Content-Type': "application/json; charset = utf-8",
            'Accept': "*/*"
        }
    });

    let responseText = await response.text();
    try {
        return JSON.parse(responseText);
    } catch (e) {
        return responseText;
    }


}