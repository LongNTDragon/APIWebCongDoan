function sortArray(arr, compareCallback) {
    var len = arr.length;
    for (var i = 0; i < len - 1; i++) {
      for (var j = i + 1; j < len; j++) {
        if (compareCallback(arr[j], arr[j]) > 0) {
          var temp = arr[i];
          arr[i] = arr[j];
          arr[j] = temp;
        }
      }
    }
  }
  
  var numbers = [3, 5, 8, 1, 2];
  sortArray(numbers, function(a, b) {
    return a - b; 
  });
  console.log(numbers); 
  
  var strings = ["banana", "apple", "orange", "grape"];
  sortArray(strings, function(a, b) {
    return a.localeCompare(b); 
  });
  console.log(strings); 