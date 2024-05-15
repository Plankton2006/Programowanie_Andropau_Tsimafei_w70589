// zad1=[]
// for (let i=0;i<10;i++){
//     var a = window.prompt("Podaj liczbe: ")
//     zad1.push(a)
// }
// console.log(zad1)
// zad2=[1,2,3,4,5,6]
// a=parseInt(prompt("Podaj liczbe: "))
// b=parseInt(prompt("Podaj indeks: "))
// var d = zad2.length+1
// for(var i=b;i<d;i++){
//     var c = zad2[i]
//     zad2[i]=a
//     a=c
// }
// console.log(zad2)
// zad3=[1,2,3,4,5]
// zad_3=[]
// for(i=zad3.length;i>=0;i--){
//     zad_3.push(zad3[i])
// }
// console.log(zad_3)
// numbers=[]
// function zad4(a){
// for (let i = 0; i < a; i++) { 
//     numbers[i] = Math.round(Math.random()*50); 
// }
// return numbers
// }
// var b=zad4(10)
// document.getElementById("zad4").innerHTML = b
// var wynik = 0
// zad5=[3,4,5,6]
// for(i=0;i<zad5.length;i++){
//     wynik += zad5[i]
// }
// console.log(wynik)

// for(i=0;i<zad5.length;i++){
//     if(zad5[i]%2 == 0)
//      console.log(zad5[i])
// }
// var wynik = []
// zad5=[3,4,5,6]
// for(i=0;i<zad5.length;i++){
//     wynik.push(zad5[i] * 3);
// }
// console.log(wynik)
// zad5=[3, 4, 5, 70589, 6]
// var i = 0
// while (zad5[i] != 70589){
//     i++
// }
// console.log(i)
// var wynik = 0
// zad5=[3,4,5,6]
// for(i=0;i<zad5.length;i++){
//     wynik += zad5[i]
// }
// console.log(wynik/zad5.length)
// zad5=[1000,45,5,69]
// var max_num = 0
// for(var i = 0; i < zad5.length; i++){
//     if(max_num < zad5[i])
//         max_num = zad5[i]
// }
// console.log(max_num)
// function il_wyst(wart){
//     var ilosc = 0
//     zad5=[1000,45,5,69,5 ,5, 7, 69, 12]
//     for(var i = 0; i < zad5.length; i++){
//         if(zad5[i] == wart){
//             ilosc++
//         }
//     }
//     return ilosc;
// }
// var wynik = il_wyst(69)
// console.log(wynik)

// var wynik = [0, 1]
// for(var i = 2; i < 100; i++){
//     wynik.push(wynik[i-2] + wynik[i-1])
// }
// console.log(wynik)

// function suma(){
//     var zad6 = [1, 61, 3, 4, 5, 20, 7, 8, 9, 10]
//     var max_num1 = 0
//     var max_num2 = 0
//     for(var i = 0; i < zad6.length; i++){
//         if(max_num1 < zad6[i]){
//             max_num2 = max_num1
//             max_num1 = zad6[i]
//         }
//         else{
//             if(max_num2 < zad6[i]){
//                 max_num2 = zad6[i]
//             }
//         }
//     }
//     return max_num1 + max_num2
// }
// var wynik = suma()
// console.log(wynik)

function usun(){
    var zad = [1, 61,3 , 3, 4, 5, 20, 5, 7, 8, 9, 3, 9, 10]
    for (var i = 0; i < zad.length; i++){
        for(var a = i; a < zad.length;a++ ){
            if(zad[i] == zad[a+1]){
                zad.splice(a+1, 1)
            }
        }
    }
    return zad
}
var wynik = usun()
console.log(wynik)