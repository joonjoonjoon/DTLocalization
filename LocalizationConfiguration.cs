using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

using DTLocalization.Internal;
using GDataDB;

namespace DTLocalization {
	public class LocalizationConfiguration : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public IEnumerable<ILocalizationTableSource> TableSources {
			get { return gdataTableSources_.Cast<ILocalizationTableSource>(); }
		}


		// PRAGMA MARK - Internal
		[Header("Outlets")]
		[SerializeField]
		private GDataLocalizationTableSource[] gdataTableSources_;

		private void Awake() {
			foreach (var tableSource in TableSources) {
				var localizationTable = tableSource.LoadTable();
				if (localizationTable == null) {
					continue;
				}

				Localization.LoadTable(localizationTable);
			}
		}
	}
}