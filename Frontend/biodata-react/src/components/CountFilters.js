import React, { useEffect } from "react";
import { useBioDataCount } from "../hooks/useBioDataCount";
import { Badge } from "antd";

const CountFilters = ({ setFiltered, datasource }) => {
  const [countedValues, setProperty] = useBioDataCount(false);

  useEffect(() => {
    setProperty("os");
  }, [setProperty]);

  return (
    <article className="filters-count-section">
      <div className="filter-category">
        <h3>Operating Sytstems</h3>
        <ul className="items">
          {countedValues &&
            Object.keys(countedValues).map(function (key, index) {
              return (
                <li
                  key={key}
                  onClick={() =>
                    setFiltered(
                      datasource.filter(bio => {
                        let conditions = bio["operatingSystems"].map(os => {
                          return (
                            os?.name &&
                            os.name.toLowerCase() === key.toLowerCase()
                          );
                        });

                        return (
                          conditions.length > 0 &&
                          conditions.reduce((acc, curr) => acc + curr) > 0
                        );
                      })
                    )
                  }
                >
                  {key} <Badge count={countedValues[key]} />
                </li>
              );
            })}
        </ul>
      </div>
      <div className="filter-category">
        <h3>ToolTypes</h3>
        <ul className="items"></ul>
      </div>
      <div className="filter-category">
        <h3>Links</h3>
        <ul className="items"></ul>
      </div>
    </article>
  );
};

export default CountFilters;
