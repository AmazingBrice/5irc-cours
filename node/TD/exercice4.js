function countLines(filename) {
    var data=fs.readFileSync(filename);
    var res=data.toString().split('\n').length;
    return Promise.resolve(res);
}
    
async function runAsyncTasks(filename) {
    const result = await countLines(filename);
    return result;
}

var fs=require('fs');
filename=process.argv[2];

runAsyncTasks(filename).then(result => console.log(result));
