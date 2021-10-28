var fs=require('fs');
filename=process.argv[2];
var data=fs.readFileSync(filename);
var res=data.toString().split('\n').length;
console.log(res);
