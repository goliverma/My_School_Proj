function Validation() {
    let valid = "";
    valid = txtFirstName();
    valid += txtLastName();
    valid += txtRollNo();
    valid += txtAddress();
    debugger;
    valid += ddlCountry();
    valid += ddlState();
    valid += ddlCity();
    if(valid == ""){
        return true;
    }
    else{
        alert(valid);
        return false;
    }
}

function changeCss(a){
    let text = document.getElementById(a);
    text.setAttribute("class","form-control");
}

function txtFirstName(){
    let text = document.getElementById('StudentName');
    let regx = /([A-Z]|[a-z])\w+/;
    if(text.value == "")
    {
        text.setAttribute("class","border-danger form-control");
        return 'Please Enter Student Name !! \n';
    }
    else if(!regx.test(text.value)){
        text.setAttribute("class","border-danger form-control");
        return 'Please Enter Only text value in Name Field !! \n';
    }
    else{
        return "";
    }
}

function txtLastName(){
    let text = document.getElementById('ClassId');
    if(text.value == "0")
    {
        text.setAttribute("class","border-danger form-control");
        return 'Please Select Student Class !! \n';
    }
    else{
        return "";
    }
}

function ddlCountry() {
    let text = document.getElementById('cid');
    if (text.value == "0") {
        text.setAttribute("class", "border-danger form-control");
        return 'Please Select Country !! \n';
    }
    else {
        return "";
    }
}

function ddlState() {
    let text = document.getElementById('sid');
    if (text.value == "0") {
        text.setAttribute("class", "border-danger form-control");
        return 'Please Select State !! \n';
    }
    else {
        return "";
    }
}

function ddlCity() {
    let text = document.getElementById('cityid');
    if (text.value == "0") {
        text.setAttribute("class", "border-danger form-control");
        return 'Please Select Student Class !! \n';
    }
    else {
        return "";
    }
}

function txtRollNo(){
    let text = document.getElementById('StudentRollNo');
    let regx = /([0-9])/;
    if(text.value == "")
    {
        text.setAttribute("class","border-danger form-control");
        return 'Please Enter Student Roll Number !! \n';
    }
    else if(!regx.test(text.value)){
        text.setAttribute("class","border-danger form-control");
        return 'Please Enter Only numeric value in Roll Number Field !! \n';
    }
    else{
        return "";
    }
}

function txtAddress(){
    let text = document.getElementById('StudentAddress');
    if(text.value == "")
    {
        text.setAttribute("class","border-danger form-control");
        return 'Please Enter Student Address! \n';
    }
    else{
        return "";
    }
}