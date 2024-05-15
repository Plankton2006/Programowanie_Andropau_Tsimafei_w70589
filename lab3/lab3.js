let a = 10
let b = 20
let c = 23.2
let p = (a+b+c)/2
console.log(a+b+c)
document.getElementById("dodawanie").innerHTML=a+b+c
console.log(typeof a ==="number")
{
    console.log("zmienna to liczba")
}
if((a+b>c)&&(a+c>b)&&(b+c>a))
{
console.log("To jest trójkąt")
}
let S=(p*(p-a)*(p-b)*(p-c))
console.log("Pole: " + S)
if((typeof a !== "number")||(typeof b !== "number")||(typeof c !== "number")){
    console.log("Dane nie są numeryczne")
}else{
    if((a+b<=c)||(a+c<=b)||(b+c<=a)){
        console.log("To nie jest trókąt")
    }else{
        let S=(p*(p-a)*(p-b)*(p-c))
console.log("Pole: " + S)   
    }
}
document.getElementById("Pole_tr").innerHTML=S
let sign = prompt("What's your name?");
alert("Hello,"+sign)
let num1=Number(prompt("Give the 1 number"));
let num2=Number(prompt("Give the 2 number"));
let suma=num1+num2;
document.getElementById("suma").innerHTML=suma
let num3=parseFloat(Number(prompt("Give the 1 number")));
let num4=parseFloat(Number(prompt("Give the 2 number")));
let num5=parseFloat(Number(prompt("Give the 3 number")));
let N_liczba=0;
if(num3>num4){
    if(num3>num5){
        console.log("Najwieksza liczba: "+num3)
        N_liczba=num3
    }
    else{
        console.log("Najwieksza liczba: "+num5)
        N_liczba=num5
    }
}
else{
    if(num4>num5)
    {
        console.log("Najwieksza liczba: "+num4)
        N_liczba=num4
    }
    else{
        console.log("Najwieksza liczba: "+num5)
        N_liczba=num5
    }
}
document.getElementById("najw_liczba").innerHTML=N_liczba
// let num6=Number(prompt("Give the 1 number"));
// let num7=Number(prompt("Give the 2 number"));
// while(num6!==0||num7!==0)
// {
//     if(num6>num7){
//         num6=num6%num7
//     }
//     else{
//         num7=num7%num6
//     }
// }
// console.log("NWD: "+a+b)