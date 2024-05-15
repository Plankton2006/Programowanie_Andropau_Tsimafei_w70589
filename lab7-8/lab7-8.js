const chValue = document.getElementById('fcountry')
const chValue1 = document.getElementById('fbirthday')
const chValue2 = document.getElementById('fphonenumber')
const chValue3 = document.getElementById('femail')
const chValue4 = document.getElementById('fname')
const chValue5 = document.getElementById('fsurname')
const chValue6 = document.getElementById('fpassword')
function checkBirthday(input){
    var birthday=input.value.split('-')[0]
    var now = new Date()
    var today = new Date(now.getFullYear(), now.getMonth(), now.getDat())
    console.log(input.value)
    if(today.getFullYear()-birthday>18){
        alert('Już masz 18 lat')
    }
    else{
        alert('Nie masz 18')
    }
}
function checkValue(input){
    if(input.value!==''){
        alert("Krasava hule")
}
    else{
        alert("Blya chel ty tupoi?")
}
    return
}
const imieInput = document.getElementById('fname') 
function checkLenght(input){
        let text=input.value
        console.log (text.length)
        return input.value.length
}
const passwordInput = document.getElementById('fpassword')
function checkPassword(input){
        let text=input.value
        i=text.length
        if(i>10 && text!=text.toLowerCase()){
            alert('Password jest bezpieczny')
        }
        else{
            alert('Password jest niebezpieczny')
        }
        return input.value.length
}
const password1 = document.getElementById('fpassword1')
function porownHaslo(input){
    if(input==passwordInput){
        alert('Hasła są jednastkowe<3')
    }
    else{
        alert('Wprowadz hasło ponownie')
    }
}
var button = document.querySelector('button');
button.onclick = function(){
  var inputs = document.querySelectorAll('input');
  for(var i = 0; i < inputs.length; i++) {
    inputs[i].checked = false;
  }
}