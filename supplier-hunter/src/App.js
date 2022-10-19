import "./App.css";
import Search from "./Search";

//TODO: OCCHIO agli useeffect che fanno un sacco di chiamate!!
function App() {
  return (
    <div className="App">
      <header>
        <div className="supplier-hunter">
          <img src="../favicon.ico" alt="hunter" />
          <span className="title">WELCOME TO THE SUPPLIER HUNTER</span>
        </div>
      </header>
      <div className="search">
        <Search />
      </div>
    </div>
  );
}

export default App;
