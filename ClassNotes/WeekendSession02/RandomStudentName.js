var names = ["Andy","Kane","Tom","Kyro","Sungmin","Ben","Joab","Jason","Edi","Zane"];


// This function will pick a random name from our list and also remove it from the list
function nextPerson() {
  // Get a random whole number between 0 and the current length of out 'names' list:
  var next = Math.floor(Math.random() * Math.floor(names.length));

  // Get the name of the person at that position in our list
  var person = names[next];

  // Remove that person from our list:
  names.splice(next,1);

  // Output the name of the person:
  return person;
}
