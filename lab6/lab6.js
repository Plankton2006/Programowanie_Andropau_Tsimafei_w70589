// class book{
//     constructor(ttl, auth, yr) {
//         this.title = ttl;
//         this.author = auth;
//         this.year = yr;
//     }
//    }
//    const book2=new book("Metro 2035","Dmitrij Glukhovski",2015)
// console.log(book2)

//    const book = {
//     title: "Metro 2033",
//     author: "Dmitrij Glukhovski",
//     year: 2005
//    };
// function dane(obj){
//     return obj.title+" - "+obj.author+" ("+obj.year+")"
// }
// console.log(book)
// console.log(dane(book))

// function book(ttl,auth,yr) {
//     this.title = ttl;
//     this.author = auth;
//     this.year = yr;
//    }
// const book1=new book("Metro 2034","Dmitrij Glukhovski",2009)
// console.log(book1)
// const student = {
//     name: "Tsimafei Andropau",
//     number: "w70589",
//     grades:[5,4,5]
//    }
// function dane(obj){
//     return obj.name+"  "+obj.number+" math:"+obj.grades[0]+" eng:"+obj.grades[1]+" fw:"+obj.grades[2]+" Srednia: "+(obj.grades[0]+obj.grades[1]+obj.grades[2])/3
// }
// console.log(student)
// console.log(dane(student))

class triangle{
    constructor(hgt, wdt, name) {
        this.height = hgt;
        this.width = wdt;
        this.name = name;
    }
}
const triangle1=new triangle(6,8,"ABC")
const triangle2=new triangle(5,12,"ABC")
const triangle3=new triangle(24,25,"ABC")
function poletr(obj){
    return (obj.height*obj.width)/2
}
console.log(poletr(triangle1))
console.log(poletr(triangle2))
console.log(poletr(triangle3))
function porown(tr1,tr2){
    if(poletr(tr1)>poletr(tr2)){
        console.log("Triangle1 jest wiekszy: "+tr1)
    }
    else{
        console.log("Triangle2 jest wiekszy: "+tr2)   
    }
}
porown(poletr(triangle1),poletr(triangle2))
class trapezoid{
    constructor(hgt, bs1, bs2, name) {
        this.height = hgt;
        this.base1 = bs1;
        this.base2 = bs2;
        this.name = name;
    }
}
const trapezoid1=new trapezoid(6,8,10,"WSIZ")
const trapezoid2=new trapezoid(5,12,6,"DEMO")
const trapezoid3=new trapezoid(3,5,7,"PZDC")
function pole(obj){
    return (obj.height*(obj.base1+obj.base2))/2
}
console.log(pole(trapezoid1))
console.log(pole(trapezoid2))
console.log(pole(trapezoid3))

function porownanie(tr1,tr2,tr3,trp1,trp2,trp3){
    let a=0
    let b=0
    if(poletr(tr1)>poletr(tr2)){
        if(poletr(tr1)>poletr(tr3)){
            console.log("Triangle1 jest najwiekszy: "+tr1)
            a=poletr(tr1)
        }
        else{
            console.log("Triangle3 jest najwiekszy: "+tr3) 
            a=poletr(tr3)
        }
    }
    else{
        if(poletr(tr2)>poletr(tr3)){
            console.log("Triangle2 jest najwiekszy: "+tr2)
            a=poletr(tr2)
        }
        else{
            console.log("Triangle3 jest najwiekszy: "+tr3) 
            a=poletr(tr3)
        }   
    }

    if(pole(trp1)>pole(trp2)){
        if(pole(trp1)>pole(trp3)){
            console.log("Trapiezoid1 jest najwiekszy: "+trp1)
            b=pole(trp1)
        }
        else{
            console.log("Trapiezoid3 jest najwiekszy: "+trp3) 
            b=pole(trp3)
        }
    }
    else{
        if(pole(trp2)>pole(trp3)){
            console.log("Trapiezoid2 jest najwiekszy: "+trp2)
            b=pole(trp2)
        }
        else{
            console.log("Trapiezoid3 jest najwiekszy: "+trp3) 
            b=pole(trp3)
        }   
    }
    if(a>b){
        console.log("Triangle wiekszy: "+a)
    }
    else{
        console.log("Trapezoid wiekszy: "+b)
    }
}
porownanie(poletr(triangle1),poletr(triangle2),poletr(triangle3),pole(trapezoid1),pole(trapezoid2),pole(trapezoid3))