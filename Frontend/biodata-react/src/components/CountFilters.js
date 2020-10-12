import React from "react";
import { useBioDataCount } from "../hooks/useBioDataCount";
import { Badge } from "antd";

const CountFilters = ({ setFiltered, datasource, setSearchTerm }) => {
  const [countedValues] = useBioDataCount([]);

  return (
    <article className="filters-count-section">
      <div className="filter-category">
        {countedValues.map(obj => {
          return (
            obj &&
            Object.keys(obj).map(key1 => {
              return (
                <>
                  <h3>{key1}</h3>
                  <ul className="items" id={key1}>
                    {key1 &&
                      Object.keys(obj[key1]).map(key2 => {
                        return (
                          <li
                            key={key2}
                            onClick={() => {
                              setFiltered(
                                datasource.filter(bio => {
                                  let conditions = bio[key1].map(property => {
                                    return (
                                      property.name.toLowerCase() ===
                                      key2.toLowerCase()
                                    );
                                  });

                                  return (
                                    conditions.length &&
                                    conditions.reduce((acc, curr) => acc + curr)
                                  );
                                })
                              );
                              setSearchTerm(key2);
                            }}
                          >
                            <span style={{ width: "fit-content" }}>{key2}</span>
                            <span style={{ marginLeft: "auto" }}>
                              <Badge count={obj[key1][key2]} />
                            </span>
                          </li>
                        );
                      })}
                  </ul>
                </>
              );
            })
          );
        })}
      </div>
    </article>
  );
};

export default CountFilters;
