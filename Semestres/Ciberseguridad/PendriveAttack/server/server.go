package main
import (
    "fmt"
    "log"
    "net/http"
    "bytes"
    "io"
    "time"
    "strconv"
    "io/ioutil"
    "os"
    "path/filepath"
    "os/exec"
)
func helloHandler(w http.ResponseWriter, r *http.Request) {
    if r.URL.Path != "/hello" {
        http.Error(w, "404 not found.", http.StatusNotFound)
        return
    }
    if r.Method != "GET" {
        http.Error(w, "Method is not supported.", http.StatusNotFound)
        return
    }
    fmt.Fprintf(w, "Hello!")
}
func receiveFile(w http.ResponseWriter, r *http.Request) {
    if r.Method != "POST" {
        http.Error(w, "Method is not supported.", http.StatusNotFound)
        return
    }
    r.ParseMultipartForm(32 << 20) // limit your max input length!
    var buf bytes.Buffer
    file, _, err := r.FormFile("file")
    if err != nil {
        panic(err)
    }
    defer file.Close()
    io.Copy(&buf, file)
    fName := strconv.FormatInt(time.Now().Unix(), 10)
    fName += ".csv"
    fName = filepath.Join("goldPot", fName)
    err = ioutil.WriteFile(fName, buf.Bytes(), os.FileMode(0644))
    if err != nil { 
        panic(err)
    }
    fmt.Println("Got it")
    buf.Reset()
    cmd := exec.Command("git", "add", ".")
    err = cmd.Run()
    if err != nil {
        fmt.Printf("Failed while adding")
    }
    cmd = exec.Command("git", "commit", "-m", "a")
    err = cmd.Run()
    if err != nil {
        fmt.Printf("Failed while committing")
    }
    cmd = exec.Command("git", "push")
    err = cmd.Run()
    if err != nil {
        fmt.Printf("Failed while pushing")
    }
    return
}
func main() {
    http.HandleFunc("/hello", helloHandler)
    http.HandleFunc("/feedMe", receiveFile)

    fmt.Printf("Starting server at port 8080\n")
    if err := http.ListenAndServe(":8080", nil); err != nil {
        log.Fatal(err)
    }
}