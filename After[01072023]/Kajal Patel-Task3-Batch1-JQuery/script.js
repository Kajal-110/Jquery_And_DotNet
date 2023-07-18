$(document).ready(function () {
  $('#addButton').on('click', function () {
    $('.firstTableBody').append(`<tr>` +
      `<td class="sno"></td>`
      +
      `<td><input class="name" id="name"  name="name"> </td>`
      +
      `<td> <input type="text" class="subject"   name="subject" ></td>`
      +
      `<td> <input type="number" class="marks"   name="marks" ></td>`
      +
      `<td>  <button  id="button" class="btn btn-dark pass" type="button"  >Accept</button>
                 <button type="button"  class="btn btn-primary fail  "  >Reject</button></td>`
      +
      `<td> <button  id="button" class="btn btn-dark deleteButton" type="button" id="deleteButton" >Delete</button></td>`
    );
  });

  $('tbody').on('click', '.deleteButton', function () {
    if (confirm("Do you want to delete this button?")) {
      $(this).closest('tr').remove();
    }
  });

  $("#myform").submit(function(e){
    e.preventDefault();
    let ans = validateData();
    if(ans){

      secondT();
      AcceptedRows();
      findPercentages();
    }
      return false;
});

   function secondT() {
    var count = $('.firstTableBody tr').length;
    for (var i = 0; i < count; i++) {
      var name = $($('.name')[i]).val();
      var subject = $($('.subject')[i]).val();
      var marks = $($('.marks')[i]).val();
      console.log(marks);
      var allBtn = $($('.btn-dark')[i]);
      // console.log(allBtn.hasClass("active"));
      var rowCount = "";
      var color = marks < 33 ? "lightgreen" : '';
      var dynamicTable =
        `<tr style="background-color:` + color + `"><td class="sno">`
        + rowCount +
        `</td><td class="name" id="name">`
        + name +
        `</td><td class="subject" id="subject">`
        + subject +
        `</td><td class="mark">`
        + marks +
        `</td></tr>`;
      if (allBtn.hasClass("active")) {
        $('.saveDatatable tbody').append(dynamicTable);
      }

    }
  }


  $('#myInput').on('keyup', function () {
    var value = $(this).val().toLowerCase();
    $('#myTable tr').filter(function () {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
  });


  $('th').click(function () {
    var table = $(this).parents('table').eq(0);
    var rows = table.find('tr:gt(0)').toArray().sort(comparer($(this).index()))
    this.asc = !this.asc
    if (!this.asc) {
      rows = rows.reverse()
    }
    for (var i = 0; i < rows.length; i++) {
      table.append(rows[i])
    }
  })
  function comparer(index) {
    return function (a, b) {
      var valA = getCellValue(a, index), valB = getCellValue(b, index)
      return $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : valA.toString().localeCompare(valB)
    }
  }
  function getCellValue(row, index) {
    return $(row).children('td').eq(index).text()
  }

  $("#firstTableBody").on("click", '.btn', function () {
    if ($(this).hasClass('btn-dark')) {
      $(this).addClass('active')
      $(this).next().removeClass('active');
    }
    if ($(this).hasClass('btn-primary')) {
      $(this).addClass('active')
      $(this).prev().removeClass('active');
    }
  });

  function findPercentages() {
    var count = $('.firstTableBody tr').length;
    var allnames = [];
    for (var i = 0; i < count; i++) {
      var name = $($('.name')[i]).val();
      
     
      allnames[i] = name[i].innerText.toLowerCase();
      let uniquename = new Set(allnames);
      let nameCount = [];
      uniquename.forEach(function (uniquename, uindex) {
        let count = 0;
        allnames.forEach(function (allname) {
          if (allname == uniquename) {
            count++;
            nameCount[uindex] = count;
          }
        });
      })
      
      let nameandmarks = [];
      nameandmarks = $.map(name, function (value, index) {
        return {
          name: $(value).text().toLowerCase(),
          marks: parseInt($(marks[index]).text())
        };
      });
      let totalmarks = [];
      $.map(nameandmarks, function (name, index) {
        totalmarks[index] = $.map(nameandmarks, function (nm, i) {
          if (nm.name == name.name) {
            return marks[index].marks = parseInt($(marks[i]).text());

          }
          else {
            return 0;
          }
        });

      });

      let c = [];
      let b = $.map(totalmarks, function (m, i) {
        c[i] = m.reduce(function (h1, h2) {
          return h1 + h2;
        });
      });

      let d = new Set(c);
      let z = $.map(Array.from(d), function (d) { return d; });
      Array.from(uniquename).forEach((m, i) => {
         console.log(nameCount);
          let row = $("<tr></tr>");
          let c1 = $("<td></td>").addClass("indext2").html(i + 1);
          let c2 = $("<td></td>").html(m);
          let c3 = $("<td></td>").html(z[i] / nameCount[m]);
          row.append(c1,c2,c3);
          tbody.append(row);
        });
    }
  }

  $("#myform").submit(function validateData(){
    isFormValid=true;
  
    var name = $(".name");
    var subject = $('.subject');
    var mark = $('.marks');
    // console.log(name,subject,mark)
    var count = $('.firstTableBody tr').length;
    for(i=0;i<count;i++){
      var name = $($('.name')[i]).val();
      var subject = $($('.subject')[i]).val();
      var marks = $($('.marks')[i]).val();
  
      if(name=="" || subject=="" || marks==""){
        alert("Please enter valid data")
        isFormValid =false
      }
    }
    if(isFormValid){
      saveDataToSecondTable(event);
    }
   
    return isFormValid;
  
  });
  


})