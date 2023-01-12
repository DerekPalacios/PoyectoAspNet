const tab1 = document.getElementById('tab-1');
const tab2 = document.getElementById('tab-2');
const tab3 = document.getElementById('tab-3');

const form1 = document.getElementById('form-1');
const form2 = document.getElementById('form-2');
const form3 = document.getElementById('form-3');

tab1.addEventListener('click', () =>{
    if(form3.classList.contains('hiden')){
        form3.classList.toggle('hiden');

        form1.classList.remove('hiden');
        form2.classList.remove('hiden');
        form1.classList.add('hiden');
        form2.classList.add('hiden');
    }
});

tab2.addEventListener('click', () =>{
    if(form1.classList.contains('hiden')){
        form1.classList.toggle('hiden');

        form2.classList.remove('hiden');
        form3.classList.remove('hiden');
        form2.classList.add('hiden');
        form3.classList.add('hiden');
    }
});

tab3.addEventListener('click', () =>{
    if(form2.classList.contains('hiden')){
        form2.classList.toggle('hiden');

        form1.classList.remove('hiden');
        form3.classList.remove('hiden');
        form1.classList.add('hiden');
        form3.classList.add('hiden');
    }
});