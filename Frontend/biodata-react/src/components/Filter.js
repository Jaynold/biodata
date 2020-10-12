import React from "react";

const Filter = ({ datasource, onFiltered, layout, render }) => {
  const onSearch = (id, searchText) =>
    onFiltered(
      datasource.filter(f =>
        f[id].toLowerCase().includes(searchText.toLowerCase())
      )
    );

  const filterData = (id, filtervalue) => false;

  const filterContainerStyle =
    layout === "column"
      ? {
          display: "flex",
          flexDirection: layout,
          margin: "0 0.3rem",
        }
      : {};

  return (
    render && (
      <div className="filters" style={filterContainerStyle}>
        {layout === "column" && (
          <div style={{ textAlign: "left", color: "snow" }}>Filters: </div>
        )}
        {render(filterData, onSearch)}
      </div>
    )
  );
};

export default Filter;
