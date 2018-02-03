var wc=document.getElementById("wc");

var htc=document.getElementById("htc");

var dtc=document.getElementById("dtc");

var tl=document.getElementById("tl");

var pt=document.getElementById("pt");

var op=document.getElementById("outPut");


wc.addEventListener("click",countWord);

htc.addEventListener("click",countTag);

dtc.addEventListener("click",countDistTag);

tl.addEventListener("click",listTags);

pt.addEventListener("click",popTags);




function countWord()
{
    
var body = top.document.body;
if(body) {
    var content = body.innerText || body.textContent;
   body.innerText.replace(/\s+|,/g,' ').split(' ')
    if(!body.innerText) {
        content = content.replace(/<script/gi,'');
    }
   
}
    op.innerHTML="word count in the page "+content.split(" ").length;
   
};


function countTag()
{

    op.innerHTML="No. of HTML Tags : "+document.getElementsByTagName('*').length;
 
};



/*function countDistTag()
{

var Disttags = Array.prototype.map.call(document.querySelectorAll("*"), function(e)
 {
  return e.nodeName; 
 }).filter(function(value, index, self) {
    return self.indexOf(value) === index;
});


alert(Disttags.length)
	
	};
 

  
function listTags()
{
	var Tags=document.querySelectorAll("*").tagName;
	var numbers = [1, 4, 9];
var roots = numbers.map(Math.sqrt);
alert(Tags);
var Disttags = Tags.map(function(e)
 {
  return e.nodeName; 
 }).filter(function(value, index, self) {
    return self.indexOf(value) === index;
});
Disttags.sort();
alert(Disttags)   
};*/
function countDistTag() {
    var tags = document.getElementsByTagName('*');
    var disTags = [];
    for (i = 0; i < tags.length; i++) {
        if (!(disTags.includes(tags[i].tagName))) {
            disTags.push(tags[i].tagName);
        }

    }

    op.innerHTML=disTags.length;

};

function listTags() {
    var tags = document.getElementsByTagName('*');
    var disTags = [];
    for (i = 0; i < tags.length; i++) {
        if (!(disTags.includes(tags[i].tagName))) {
            disTags.push(tags[i].tagName);
        }
	}
	disTags.sort()
	op.innerHTML=disTags;
	};

function popTags(){
var body = top.document.body;
if(body) {
    var content = body.innerText || body.textContent;
   body.innerText.replace(/\s+|,/g,' ').split(' ')
    if(!body.innerText) {
        content = content.replace(/<script/gi,'');
    }
   
}
alert(content.split(' ').length);
alert(content)
};