$(document).ready(function() {
  $("form").submit(function() {
  var fNameInput = $("input#firstName").val();
  var lNameInput = $("input#lastName").val();
  var phoneNumberInput = $("input#phoneNumber").val();
  var addressInput = $("input#address").val();
  $("div#addContact").fadeToggle("fast");
  $('form').unbind('submit').submit();
//output

  $("body").append("<body style='align-content: center'>");
  $("body").append("<div align='center' id='divOut'>");
  $("body").append("<h2><b>You created a contact!</b></h2>");
  $("body").append("<p>FirstName: "+fNameInput+"</p>");
  $("body").append("<p>LastName: "+lNameInput+"</p>");
  $("body").append("<p>PhoneNumber: "+phoneNumberInput+"</p>");
  $("body").append("<p>Address: "+addressInput+"</p>");
  $("body").append("<br>");
  $("body").append("<br>");
  $("body").append("<p><em>Returning you to the New Contact Form...</em></p>");
  $("body").append("<br>");
  $("body").append("<br>");
  $("body").append("<a href='/contacts/new'>Add Another Contact   </a>");
  $("body").append("<a href='/contacts/clear'>Clear all Contacts   </a>");
  $("body").append("<a href='/contacts'>View all Contacts   </a>");
  $("body").append("<a href='/'>Return to Homepage</a>   ");
  $("body").append("</div>");
  });
});
