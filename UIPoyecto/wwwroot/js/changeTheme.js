const btn_Theme = document.getElementById('btn_Theme');

window.onload = function () {
    if (typeof (localStorage) !== "undefined") {
        let themeMode = localStorage.getItem('theme');

        if (themeMode == '"dark-theme-variables"') {
            ChangeTheme();
            toggleButton();
        }
    }
};

function ChangeTheme() {
    document.body.classList.toggle('dark-theme-variables');
};

function toggleButton() {
    btn_Theme.querySelector('div:nth-child(1)').classList.toggle('active');
    btn_Theme.querySelector('div:nth-child(2)').classList.toggle('active');
}

btn_Theme.addEventListener('click', () => {
    ChangeTheme();
    toggleButton();
    localStorage.setItem("theme", JSON.stringify(document.body.classList.toString()));

    let themeMode = localStorage.getItem('theme');

    if (themeMode == '"dark-theme-variables"') {
        Chart.defaults.color = '#fff';
        Chart.defaults.borderColor = '#fff';
    }
    else {
        Chart.defaults.color = '#000';
        Chart.defaults.borderColor = '#000';
    };
});