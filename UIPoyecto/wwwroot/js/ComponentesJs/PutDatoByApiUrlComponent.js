export default async function SaveObjectData(url,objData){

    let response = await fetch(url, {
        method: "POST",
        headers: {
            'Content-Type': "application/json; charset = utf-8",
            'Accept': "*/*"
        },
        body: JSON.stringify(objData)
    });

    return response;
};