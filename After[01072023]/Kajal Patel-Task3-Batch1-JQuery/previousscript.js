
var table = document.getElementById("myTable");
var sNo = 6;
var sno3 = 1;
addNewRow = () => {
  var row = table.insertRow();
  var call1 = row.insertCell(0);

  var call2 = row.insertCell(1);
  var call3 = row.insertCell(2);
  var call4 = row.insertCell(3);
  var call5 = row.insertCell(4);
  var call6 = row.insertCell(5);
  call1.setAttribute("data-label","S.No:");
  call2.setAttribute("data-label","Name:");
  call3.setAttribute("data-label","Subject:");
  call4.setAttribute("data-label","Marks:");
  call5.setAttribute("data-label","Result:");
  call6.setAttribute("data-label","Action:");

  call1.innerHTML = `${sNo++} `
  call2.innerHTML = '<input type="text" placeholder="Name" class=" name" id="name" name="name"   title=" you can enter only alphabates here"   / > '
  call3.innerHTML = '<input type="text" placeholder="Subject" class="subject"  id="subject" name="subject"  />'
  call4.innerHTML = '<input type="Number" placeholder="Mark" class="marks"  name="quantity" name="marks"  /> '

  call5.innerHTML = '<button  class="btn btn-dark " type="button" onclick=" visited(this)">Accept</button><button type="button" class="btn btn-primary mx-1" onclick="notVisited(this)">Reject</button>'
  call6.innerHTML = '<button type="button" class="btn btn-dark " onclick="deleteRow(this)">Delete</button>'
}




deleteRow = (a) => {
  if (confirm("Are you want to delete")) {
    a.parentNode.parentNode.remove();
    sNo--;
    var table = document.getElementById("myTable");
    table.forEach(i => {
      table.rows[i].cells[0].innerHTML = i;
    });
  }
}




saveDataToSecondTable = (event) => {

  event.preventDefault()
 
  demoList.innerHTML =
    `  <thead >
    <tr class="header">
      <th>S.No</th>
      <th onclick="sortDataInSecondTable(1)">Name</th>
      <th onclick="sortDataInSecondTable(2)">Subject</th>
      <th>Mark</th> 
    </tr>
  </thead>
  <tbody>
   
  </tbody>`

  var name = document.getElementsByClassName('name');
  var subject = document.getElementsByClassName('subject');
  var mark = document.getElementsByClassName('marks');
  for (let i = 0; i < table.rows.length - 1; i++) {
    var row = demoList.insertRow(-1);
    var call1 = row.insertCell(0);
    var call2 = row.insertCell(1);
    var call3 = row.insertCell(2);
    var call4 = row.insertCell(3);
    call1.classList.add("sno2")

    call2.innerHTML = name[i].value;
    call3.innerHTML = subject[i].value;
    call4.innerHTML = mark[i].value;
    if (mark[i].value < 33) {
      row.style.backgroundColor = "pink";
    }

  }
  // if (checkValidation()) {
  
  // };
  AcceptedRows();
  findPercentages();

}

searchDataInSecondTable = () => {
  let input, filter, table, tr, td, i, txtValue1, textvalue2;
  input = document.getElementById("myInput");
  filter = input.value.toUpperCase();
  table = document.getElementById("demoList");
  tr = table.getElementsByTagName("tr");
  for (i = 0; i < tr.length; i++) {
    tdname = tr[i].getElementsByTagName("td")[1];
    tdsubject = tr[i].getElementsByTagName('td')[2]
    if (tdname || tdsubject) {
      txtValue1 = tdname.textContent || tdname.innerText;
      txtValue2 = tdsubject.textContent || tdsubject.innerText;
      if ((txtValue1.toUpperCase().indexOf(filter) > -1) || (txtValue2.toUpperCase().indexOf(filter) > -1)) {
        tr[i].style.display = "";
      } else {
        tr[i].style.display = "none";
      }
    }
  }
}

sortDataInSecondTable = (n) => {
  var table, rows, switching, i, x, y, shouldSwitch;
  table = document.getElementById("demoList");
  switching = true;
  while (switching) {
    switching = false;
    rows = table.rows;
    for (i = 1; i < (rows.length - 1); i++) {
      shouldSwitch = false;
      x = rows[i].getElementsByTagName("TD")[n];
      y = rows[i + 1].getElementsByTagName("TD")[n];
      if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
        shouldSwitch = true;
        break;
      }
    }
    if (shouldSwitch) {
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
    }
  }
}

function visited(a) {
  a.classList.add('salmon');
  a.parentElement.lastElementChild.classList.remove('salmon');

}
function notVisited(a) {
  a.classList.add('salmon');
  a.parentElement.firstElementChild.classList.remove('salmon');

}



function findPercentages() {

  var name = document.getElementsByClassName('name ');
  var mark = document.getElementsByClassName('marks');
  var markArr = []

  percentages = document.getElementById("percentages");

  percentages.innerHTML = `
<thead >
<tr class="header">
  <th>S.No</th>
  <th>Name</th>
   <th>Mark</th> 
</tr>
</thead>
<tbody id="tbody">

</tbody>`
  tbody = document.getElementById('tbody')

  let tableNames = [];
  for (let i = 0; i < name.length; i++) {
    tableNames[i] = name[i].value;
    //console.log(tableNames[i]);
  }
  uniquename = new Set(tableNames);

  //console.log(uniquename);
  let nameCount = [];
  uniquename.forEach((uniquename, uindex) => {
    count = 0;
    tableNames.forEach(tableNames => {

      if (tableNames == uniquename) {

        count++;
        nameCount[uindex] = count;
      }
    });
  });
  //console.log(nameCount);


  let nameandmarks = []
  nameandmarks = Array.from(name).map((name, index) => {
    return {
      name: name.value,
      marks: mark[index].value
    }
  })
  totalmarks = []
  totalmarks = nameandmarks.map((name, index) => {
    return nameandmarks.map((nm, i) => {
      if (nm.name == name.name) {
        //console.log(mark.mark);
        return mark[index].marks = parseInt(mark[i].value)
      }
      else {
        return 0

      }
    })
  })

  let c = []

  let b = totalmarks.forEach((m, i) => {
    c[i] = m.reduce((h1, h2) => {
      return h1 + h2;
    });
  })
  let d = new Set(c);
  console.log(uniquename);
  console.log(d);
  let z = Array.from(d).map(d => { return d })
  Array.from(uniquename).forEach((m, i) => {

    let row = document.createElement("tr");
    var call1 = row.insertCell(0);

    let call2 = row.insertCell(1);
    let call3 = row.insertCell(2);
    call1.innerHTML = `${sno3++} `
    call2.innerHTML = m;
    call3.innerHTML = z[i] / nameCount[m] + '%';
    tbody.appendChild(row);
  })
}



// var ele= document.getElementsByClassName('btn-info');
// ele.addEventListener("submit",validateTable=()=>{
//   var table = document.getElementById("myTable");
//   let flag=true;
//   var regName = /^[a-zA-Z]+$/;
//   var name = document.getElementsByClassName("name");
//   var subject = document.getElementsByClassName('subject');
//   var mark = document.getElementsByClassName('marks');
//   var alertMessage="";
//   for( var i=0; i<table.rows.length; i++){
//     var a=name[i].value;
//     var b=subject[i].value;
//     var c=mark[i].value;

//       if( document.myForm.name.value==""){
//         document.getElementById('error').innerHTML="please enter your name";
//         alert("name must be filled  out");
//        flag= false;
//       }
//       else if(b=="" ||!regName.test(b)){
//         alert("subject must be filled  out");
//         flag= false;
//       }
//       else if(c==""|| c<0  && c>100){
//         alert("name must be filled  out");
//         flag= false;

//       }
      
//   }
  
//   return flag;
// });

// function validateTable() {

//   var table = document.getElementById("myTable");
//   let flag=true;
//   var regName = /^[a-zA-Z]+$/;
//   var name = document.getElementsByClassName("name");
//   var subject = document.getElementsByClassName('subject');
//   var mark = document.getElementsByClassName('marks');
 
//   for( var i=0; i<table.rows.length; i++){
//     var a=name[i].value;
//     var b=subject[i].value;
//     var c=mark[i].value;
//     if( document.myForm.name.value==""){
//       document.getElementById('error').innerHTML="please enter your name";
//       alert("name must be filled  out");
//      flag= false;
//     }
//       else if(b=="" ||!regName.test(b)){
//         alert("subject must be filled  out");
//         flag= false;
//       }
//       else if(c==""|| c<0  && c>100){
//         alert("name must be filled  out");
//         flag= false;

//       }
      
//   }
//   // return true;
//   return flag;

// }


// var flag=0;
// function nameValidation(){
// var name=myForm.name.value;
// if(name==""){
//   document.getElementsByClassName('error').innerHTML="Enter your name";
//   flag=1;
// }
// }
// function subjectValidation(){
//   var subject=myForm.subject.value;
//   if(subject==""){
//     document.getElementsByClassName('error').innerHTML="Enter your subject";
//     flag=1;
//   }
// }
// function markValidation(){
//   var mark=myForm.marks.value;
//   if(mark=="" || mark<0 && mark>100){
//     document.getElementsByClassName('error').innerHTML="Enter your mark";
//     flag=1;
//   }
// }

// function checkValidation(form){
//   flag=0;
//   nameValidation();
//   subjectValidation();
//   markValidation();
//   if(flag==1){
//     return false;
//   }
//   else{
//     return true
//   }
// }

function validateData(){
  isFormValid=true;

  var name = document.getElementsByClassName("name");
  var subject = document.getElementsByClassName('subject');
  var mark = document.getElementsByClassName('marks');
  // console.log(name,subject,mark)

  for(i=0;i<name.length;i++){
    let nameVal=name[i].value
    let subjectVal=subject[i].value
    let marksVal=marks[i].value

    if(nameVal=="" || subjectVal=="" || marksVal==""){
      alert("Please enter valid data")
      isFormValid =false
    }
  }
  if(isFormValid){
    saveDataToSecondTable(event);
  }
 
  return isFormValid;

}



function AcceptedRows() {
  var name = document.getElementsByClassName('name ');
  var mark = document.getElementsByClassName('marks');
  var subject = document.getElementsByClassName('subject');
  acceptedRows = document.getElementById("acceptedRows");
  acceptedRows.innerHTML = `
<thead >
<tr class="header" >
  <th>S.No</th>
  <th>Name</th>
   <th>Mark</th> 
   <th>Result</th>
</tr>
</thead>
<tbody id="acceptedRows">

</tbody>`


  var sno3 = 1;
  var acceptRow = document.querySelectorAll('.btn-dark');
  for (let i = 0; i < name.length; i++) {


    if (acceptRow[i].classList.contains("salmon")) {

      var row = acceptedRows.insertRow();
      var call1 = row.insertCell(0);
      var call2 = row.insertCell(1);
      var call3 = row.insertCell(2);
      var call4 = row.insertCell(3);

      call1.innerHTML = `${sno3++} `
      call2.innerHTML = name[i].value;
      call3.innerHTML = subject[i].value;
      call4.innerHTML = `<button  class="btn btn-dark " type="button" >Accepted</button>`
    }
   
  }
}


