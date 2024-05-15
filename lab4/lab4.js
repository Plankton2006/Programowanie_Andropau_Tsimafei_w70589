for(let i=10;i>0;i--){
    console.log(i)
    setInterval(1000);
}
console.log("Happy New Year")
function silnia(liczba){
    // for(liczba;liczba>0;x--){
    //     x=1*liczba
    // }
    while(liczba>1){
        iloczyn*=liczba
        liczba--
    }
    return iloczyn
}
let lb=parseFloat(prompt("Silnia Jakiej liczby policzyć: "))
function silniaRek(liczba){
if(liczba==1){
  return 1
}
else{
    return silniaRek(liczba-1)*liczba;
}
}
let wynik=silniaRek(lb)
console.log(wynik)
let wiek=parseFloat(prompt("Ile Pan(-i) ma lat: "))
function pelnolecie(wiek){
if(wiek<18){
    window.open("baby.html")
}
else{
    window.open("adult.html")
}
}
let laty=pelnolecie(wiek)
function changeColor(button) {
    var buttons = document.getElementsByClassName("button");
    for (var i = 0; i < buttons.length; i++) {
        if (buttons[i] === button) {
            if (buttons[i].style.backgroundColor === "") {
                buttons[i].style.backgroundColor = "#f5d9aa"; 
            } else {
                buttons[i].style.backgroundColor = ""; 
            }
        } 
        else {
            buttons[i].style.backgroundColor = "";
        }
    }
}
function widocznosc(button){
    var button1 = document.getElementsByClassName("b1")
    let text = document.getElementsById("wid")
    if(button1===button){
        document.getElementsById('wid')
    }
}
function temperatureConverter1(valNum1) {
    valNum1 = parseFloat(valNum1);
    document.getElementById("outputCelsius").innerHTML = (valNum1-32) / 1.8;
  } 
  function temperatureConverter2(valNum2) {
    valNum2 = parseFloat(valNum2);
    document.getElementById("outputFahrenheit").innerHTML=(valNum2*1.8)+32;
  }

let a=parseFloat(prompt("Podaj 1 liczbe: "))
let b=parseFloat(prompt("Podaj 2 liczbe: "))
c=prompt("Jaka prace chcesz wylonac: ")
if(c=="+"){
    alert(a+b)
}
if(c=="-"){
 alert(a-b)
}
if(c=="*"){
    alert(a*b)
}
if(c=="/"){
    alert(a/b)
}
if(c=="^"){
    alert(a**b)
}
  